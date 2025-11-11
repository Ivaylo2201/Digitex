using Backend.Application.Dtos.User;
using Backend.Application.Interfaces.Services;
using Backend.Application.Validators;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Backend.Infrastructure.Services.Entities;

public class UserService(
    ILogger<UserService> logger,
    IUserRepository userRepository,
    ITokenService tokenService,
    IEmailCryptoService emailCryptoService,
    IEmailSendingService emailSendingService) : IUserService
{
    private const string Source = nameof(UserService);
    
    public async Task<Result<string>> SignInAsync(SignInDto signInDto, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Validating SignIn request body...", Source);
        var validationResult = await new SignInValidator().ValidateAsync(signInDto, stoppingToken);

        if (!validationResult.IsValid)
        {
            var serializedDto = JsonConvert.SerializeObject(signInDto);
            var errors = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
            
            logger.LogError("[{Source}]: Sign in validation failed for {SerializedDto}. Errors: {Errors}", Source, serializedDto, errors);
            return Result<string>.Failure(ErrorType.ValidationFailed, validationResult.Errors.ToObject());
        }

        var user = await userRepository.GetOneByCredentialsAsync(signInDto.Email, signInDto.Password, stoppingToken);

        if (user is null)
            return Result<string>.Failure(ErrorType.InvalidCredentials);
        
        return Result<string>.Success(tokenService.GenerateToken(user));
    }

    public async Task<Result> SignUpAsync(SignUpDto signUpDto, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Validating SignUp request body...", Source);
        var validationResult = await new SignUpValidator().ValidateAsync(signUpDto, stoppingToken);

        if (!validationResult.IsValid)
        {
            var serializedDto = JsonConvert.SerializeObject(signUpDto);
            var errors = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
            
            logger.LogError("[{Source}]: Sign up validation failed for {SerializedDto}. Errors: {Errors}", Source, serializedDto, errors);
            return Result<string>.Failure(ErrorType.ValidationFailed, validationResult.Errors.ToObject());
        }

        try
        {
            var user = await userRepository.CreateAsync(new User
            {
                Username = signUpDto.Username,
                Password = signUpDto.Password,
                Email = signUpDto.Email,
                Cart = new Cart()
            }, stoppingToken);
            
            await emailSendingService.SendVerificationMailAsync(user, stoppingToken);
            return Result.Success();
        }
        catch (DbUpdateException)
        {
            logger.LogError("[{Source}]: Email={Email} is already taken.", Source, signUpDto.Email);
            return Result.Failure(ErrorType.EmailTaken);       
        }
    }

    public async Task<Result> VerifyUserAsync(string token, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Starting verification process...", Source);
        
        try
        {
            var email = emailCryptoService.Decrypt(token);
            var isVerificationSuccessful = await userRepository.VerifyUserAsync(email, stoppingToken);
            return isVerificationSuccessful ? Result.Success() : Result.Failure(ErrorType.InvalidCredentials);    
        }
        catch (Exception ex)
        {
            logger.LogError("[{Source}]: {ExceptionName} occurred while decrypting email. Exception message: {ExceptionMessage}", Source, ex.GetType().Name, ex.Message);
            return Result.Failure(ErrorType.CryptographyError);
        }
    }
}