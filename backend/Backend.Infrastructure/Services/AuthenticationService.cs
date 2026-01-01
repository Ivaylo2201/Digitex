using Backend.Application.Contracts.Authentication.SignIn;
using Backend.Application.Contracts.Authentication.SignUp;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Email;
using Backend.Application.Interfaces.Tokens;
using Backend.Application.Validators;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Backend.Infrastructure.Services;

public class AuthenticationService(
    ILogger<AuthenticationService> logger,
    IUserRepository userRepository,
    IUserTokenRepository userTokenRepository,
    IJwtService jwtService,
    ITokenService tokenService,
    IEmailSenderService emailSenderService,
    IUrlService urlService) : IAuthenticationService
{
    private const string Source = nameof(AuthenticationService);
    
    public async Task<Result<string>> SignUpAsync(SignUpRequest signUpRequest, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Validating SignUp request body...", Source);
        var validationResult = await new SignUpValidator().ValidateAsync(signUpRequest, stoppingToken);

        if (!validationResult.IsValid)
        {
            var serializedDto = JsonConvert.SerializeObject(signUpRequest);
            var errors = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
            
            logger.LogError("[{Source}]: Sign up validation failed for {SerializedDto}. Errors: {Errors}", Source, serializedDto, errors);
            return Result<string>.Failure(StatusCodes.Status400BadRequest, ErrorType.ValidationFailed, details: validationResult.Errors.ToObject());
        }

        try
        {
            var user = await userRepository.CreateAsync(new User
            {
                Username = signUpRequest.Username,
                Password = signUpRequest.Password,
                Email = signUpRequest.Email,
                Cart = new Cart()
            }, stoppingToken);
            
            await RequestAccountVerificationAsync(user, stoppingToken);
            
            return Result<string>.Success(StatusCodes.Status201Created, $"Visit {user.Email} to verify your account.");
        }
        catch (Exception ex)
        {
            logger.LogException(Source, ex, "creating user or account verification token");
            return Result<string>.Failure(StatusCodes.Status400BadRequest, ErrorType.DatabaseError);       
        }
    }

    public async Task<Result<(string Token, Role Role)>> SignInAsync(SignInRequest signInRequest, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Validating SignIn request body...", Source);
        var validationResult = await new SignInValidator().ValidateAsync(signInRequest, stoppingToken);

        if (!validationResult.IsValid)
        {
            var serializedDto = JsonConvert.SerializeObject(signInRequest);
            var errors = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
            
            logger.LogError("[{Source}]: Sign in validation failed for {SerializedDto}. Errors: {Errors}", Source, serializedDto, errors);
            return Result<(string, Role)>.Failure(StatusCodes.Status400BadRequest, ErrorType.ValidationFailed, validationResult.Errors.ToObject());
        }

        var user = await userRepository.GetOneByCredentialsAsync(signInRequest.Email, signInRequest.Password, stoppingToken);

        return user is null ?
            Result<(string, Role)>.Failure(StatusCodes.Status400BadRequest, ErrorType.InvalidCredentials) :
            Result<(string, Role)>.Success(StatusCodes.Status200OK, (jwtService.GenerateToken(user), user.Role));
    }
    
    private async Task RequestAccountVerificationAsync(User user, CancellationToken stoppingToken)
    {
        var rawToken = tokenService.GenerateToken();
        var hashedToken = tokenService.HashToken(rawToken);
            
        await userTokenRepository.CreateAsync(UserToken.Create(user, hashedToken, UserTokenType.AccountVerification), stoppingToken);
        await emailSenderService.SendAccountVerificationEmailAsync(user, urlService.GetAccountVerificationUrl(rawToken), stoppingToken);
    }
}