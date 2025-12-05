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
    IEmailSendingService emailSendingService,
    IUrlService urlService) : IUserService
{
    private const string Source = nameof(UserService);
    
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
            
            await RequestAccountVerificationAsync(user, stoppingToken);
            
            return Result<string>.Success(StatusCodes.Status201Created, $"Visit {user.Email} to verify your account.");
        }
        catch (DbUpdateException ex)
        {
            logger.LogException(Source, ex, "creating user or account verification token");
            return Result<string>.Failure(StatusCodes.Status400BadRequest, ErrorType.DatabaseError);       
        }
    }
    
    public async Task<Result<(string Token, Role Role)>> CompleteAccountVerificationAsync(AccountVerificationDto accountVerificationDto, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Completing account verification...", Source);
        
        var hashedToken = tokenService.HashToken(accountVerificationDto.Token);
        var userToken = await userTokenRepository.GetActiveTokenByHashWithUserAsync(hashedToken, stoppingToken);

        if (userToken is null)
            return Result<(string, Role)>.Failure(StatusCodes.Status404NotFound);

        if (userToken.UserTokenType is not UserTokenType.AccountVerification)
            return Result<(string, Role)>.Failure(StatusCodes.Status400BadRequest, ErrorType.InvalidTokenType);
        
        var user = await userRepository.VerifyUserAsync(userToken.User.Id, stoppingToken);
        await userTokenRepository.DeleteAsync(userToken.Id, stoppingToken);
        
        return user is null ? 
            Result<(string, Role)>.Failure(StatusCodes.Status404NotFound) : 
            Result<(string, Role)>.Success(StatusCodes.Status200OK, (jwtService.GenerateJwt(user), user.Role));
    }
    
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

    public async Task<Result<string>> RequestPasswordResetAsync(RequestPasswordResetDto requestPasswordResetDto, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Requesting password reset for User with Email={Email}...", Source, requestPasswordResetDto.Email);
        
        var user = await userRepository.GetOneByEmailAsync(requestPasswordResetDto.Email, stoppingToken);

        if (user is null)
            return Result<string>.Failure(StatusCodes.Status404NotFound);
        
        var rawToken = tokenService.GenerateToken();
        var hashedToken = tokenService.HashToken(rawToken);

        await userTokenRepository.CreateAsync(
            UserToken.Create(user, hashedToken, UserTokenType.PasswordReset),
            stoppingToken
        );
        
        await emailSendingService.SendPasswordResetEmailAsync(user, urlService.PasswordResetUrl(rawToken) ,stoppingToken);
        return Result<string>.Success(StatusCodes.Status200OK, $"Visit {user.Email} to reset your password.");
    }
    
    public async Task<Result<string>> CompletePasswordResetAsync(CompletePasswordResetDto completePasswordResetDto, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Completing password reset...", Source);
        
        var hashedToken = tokenService.HashToken(completePasswordResetDto.Token);
        var userToken = await userTokenRepository.GetActiveTokenByHashWithUserAsync(hashedToken, stoppingToken);
        
        if (userToken is null)
            return Result<string>.Failure(StatusCodes.Status404NotFound);

        if (userToken.UserTokenType is not UserTokenType.PasswordReset)
            return Result<string>.Failure(StatusCodes.Status400BadRequest, ErrorType.InvalidTokenType);
        
        await userRepository.ResetPasswordAsync(userToken.User.Id, completePasswordResetDto.NewPassword, stoppingToken);
        await userTokenRepository.DeleteAsync(userToken.Id, stoppingToken);

        return Result<string>.Success(StatusCodes.Status200OK, "Password has been successfully reset.");
    }
    
    private async Task RequestAccountVerificationAsync(User user, CancellationToken stoppingToken)
    {
        logger.LogInformation("[{Source}]: Requesting account verification for User with Username={Username}...", Source, user.Username);
        
        var rawToken = tokenService.GenerateToken();
        var hashedToken = tokenService.HashToken(rawToken);
            
        await userTokenRepository.CreateAsync(UserToken.Create(user, hashedToken, UserTokenType.AccountVerification), stoppingToken);
        await emailSendingService.SendVerificationEmailAsync(user, urlService.AccountVerificationUrl(rawToken), stoppingToken);
    }
}