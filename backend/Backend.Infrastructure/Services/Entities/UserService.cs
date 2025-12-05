using Backend.Application.Dtos.User;
using Backend.Application.Interfaces.Services;
using Backend.Application.Validators;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Backend.Infrastructure.Services.Entities;

public class UserService(
    ILogger<UserService> logger,
    IUserRepository userRepository,
    IUserTokenRepository userTokenRepository,
    IJwtService jwtService,
    ITokenService tokenService,
    IEmailSendingService emailSendingService) : IUserService
{
    private const string Source = nameof(UserService);
    
    public async Task<Result<(string Token, Role Role)>> SignInAsync(SignInDto signInDto, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Validating SignIn request body...", Source);
        var validationResult = await new SignInValidator().ValidateAsync(signInDto, stoppingToken);

        if (!validationResult.IsValid)
        {
            var serializedDto = JsonConvert.SerializeObject(signInDto);
            var errors = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
            
            logger.LogError("[{Source}]: Sign in validation failed for {SerializedDto}. Errors: {Errors}", Source, serializedDto, errors);
            return Result<(string, Role)>.Failure(StatusCodes.Status400BadRequest, ErrorType.ValidationFailed, validationResult.Errors.ToObject());
        }

        var user = await userRepository.GetOneByCredentialsAsync(signInDto.Email, signInDto.Password, stoppingToken);

        return user is null ?
            Result<(string, Role)>.Failure(StatusCodes.Status400BadRequest, ErrorType.InvalidCredentials) :
            Result<(string, Role)>.Success(StatusCodes.Status200OK, (jwtService.GenerateJwt(user), user.Role));
    }

    public async Task<Result<string>> SignUpAsync(SignUpDto signUpDto, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Validating SignUp request body...", Source);
        var validationResult = await new SignUpValidator().ValidateAsync(signUpDto, stoppingToken);

        if (!validationResult.IsValid)
        {
            var serializedDto = JsonConvert.SerializeObject(signUpDto);
            var errors = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
            
            logger.LogError("[{Source}]: Sign up validation failed for {SerializedDto}. Errors: {Errors}", Source, serializedDto, errors);
            return Result<string>.Failure(StatusCodes.Status400BadRequest, ErrorType.ValidationFailed, details: validationResult.Errors.ToObject());
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
            
            var rawToken = tokenService.GenerateToken();

            await userTokenRepository.CreateAsync(CreateUserToken(user, rawToken, UserTokenType.AccountVerification), stoppingToken);
            await emailSendingService.SendVerificationEmailAsync(user, rawToken, stoppingToken);
            
            return Result<string>.Success(StatusCodes.Status201Created, user.Email);
        }
        catch (DbUpdateException ex)
        {
            logger.LogError("[{Source}]: {ExceptionName} occurred creating user or account verification token. Exception message: {ExceptionMessage}", Source, ex.GetType().Name, ex.InnerException?.Message ?? ex.Message);
            return Result<string>.Failure(StatusCodes.Status400BadRequest, ErrorType.DatabaseError);       
        }
    }

    public async Task<Result<(string Token, Role Role)>> VerifyUserAsync(VerifyUserDto verifyUserDto, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Starting verification process...", Source);

        try
        {
            var userToken = await userTokenRepository.GetActiveTokenByHashWithUserAsync(tokenService.HashToken(verifyUserDto.Token), stoppingToken);

            if (userToken is null)
                return Result<(string, Role)>.Failure(StatusCodes.Status404NotFound);

            if (userToken.UserTokenType is not UserTokenType.AccountVerification)
                return Result<(string, Role)>.Failure(StatusCodes.Status400BadRequest, ErrorType.InvalidTokenType);
            
            var user = await userRepository.VerifyUserAsync(userToken.User.Id, stoppingToken);
            
            return user is null ? 
                Result<(string, Role)>.Failure(StatusCodes.Status404NotFound) : 
                Result<(string, Role)>.Success(StatusCodes.Status200OK, (jwtService.GenerateJwt(user), user.Role));
        }
        catch (Exception ex)
        {
            logger.LogError("[{Source}]: {ExceptionName} occurred while decrypting email. Exception message: {ExceptionMessage}", Source, ex.GetType().Name, ex.Message);
            return Result<(string, Role)>.Failure(StatusCodes.Status400BadRequest, ErrorType.CryptographyError);  
        }
    }

    public async Task<Result> ResetPasswordAsync(ResetPasswordDto resetPasswordDto, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Starting password reset process...", Source);
        return Result<(string, Role)>.Failure(StatusCodes.Status400BadRequest, ErrorType.CryptographyError);  // dummy
    }

    private UserToken CreateUserToken(User user, string rawToken, UserTokenType userTokenType)
    {
        const int accountVerificationTokenExpirationInMinutes = 1440;
        const int passwordResetTokenExpirationInMinutes = 30;
        const int defaultTokenExpirationInMinutes = 0;
        
        var createdAt = DateTime.UtcNow;
        var expiresAt = createdAt.AddMinutes(userTokenType switch
        {
            UserTokenType.AccountVerification => accountVerificationTokenExpirationInMinutes,
            UserTokenType.PasswordReset => passwordResetTokenExpirationInMinutes,
            _ => defaultTokenExpirationInMinutes
        });
        
        return new UserToken
        {
            User = user,
            Hash = tokenService.HashToken(rawToken),
            UserTokenType = userTokenType,
            CreatedAt = createdAt,
            ExpiresAt = expiresAt
        };
    }
}