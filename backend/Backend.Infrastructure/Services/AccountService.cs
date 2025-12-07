using Backend.Application.Dtos.User;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services;

public class AccountService(
    ILogger<AccountService> logger,
    IUserRepository userRepository,
    IUserTokenRepository userTokenRepository,
    IJwtService jwtService,
    ITokenService tokenService,
    IEmailSendingService emailSendingService,
    IUrlService urlService) : IAccountService
{
    private const string Source = nameof(AccountService);
    
    public async Task<Result<(string Token, Role Role)>> CompleteAccountVerificationAsync(AccountVerificationDto accountVerificationDto, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Completing account verification...", Source);
        
        var hashedToken = tokenService.HashToken(accountVerificationDto.Token);
        var userToken = await userTokenRepository.GetActiveTokenByHashWithUserAsync(hashedToken, stoppingToken);

        if (userToken is null)
        {
            logger.LogWarning("[{Source}]: No active UserToken was found by hash.", Source);
            return Result<(string, Role)>.Failure(StatusCodes.Status404NotFound);
        }

        if (userToken.UserTokenType is not UserTokenType.AccountVerification)
        {
            logger.LogWarning("[{Source}]: UserToken type is invalid for account verification.", Source);
            return Result<(string, Role)>.Failure(StatusCodes.Status400BadRequest, ErrorType.InvalidTokenType);
        }
        
        logger.LogInformation("[{Source}]: Verifying User with Username={Username}...", Source, userToken.User.Username);
        var user = await userRepository.VerifyUserAsync(userToken.User.Id, stoppingToken);
        
        await userTokenRepository.DeleteAsync(userToken.Id, stoppingToken);
        
        return user is null ? 
            Result<(string, Role)>.Failure(StatusCodes.Status404NotFound) : 
            Result<(string, Role)>.Success(StatusCodes.Status200OK, (jwtService.GenerateToken(user), user.Role));
    }
    
    public async Task<Result<string>> RequestPasswordResetAsync(RequestPasswordResetDto requestPasswordResetDto, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Requesting password reset for User with Email={Email}...", Source, requestPasswordResetDto.Email);
        
        var user = await userRepository.GetOneByEmailAsync(requestPasswordResetDto.Email, stoppingToken);

        if (user is null)
        {
            logger.LogWarning("[{Source}]: User with Email={Email} was not found.", Source, requestPasswordResetDto.Email);
            return Result<string>.Failure(StatusCodes.Status404NotFound);
        }
        
        var rawToken = tokenService.GenerateToken();
        var hashedToken = tokenService.HashToken(rawToken);
        await userTokenRepository.CreateAsync(UserToken.Create(user, hashedToken, UserTokenType.PasswordReset), stoppingToken);
        
        await emailSendingService.SendPasswordResetEmailAsync(user, urlService.GetPasswordResetUrl(rawToken), stoppingToken);
        return Result<string>.Success(StatusCodes.Status200OK, $"Visit {user.Email} to reset your password.");
    }
    
    public async Task<Result<string>> CompletePasswordResetAsync(CompletePasswordResetDto completePasswordResetDto, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Completing password reset...", Source);
        
        var hashedToken = tokenService.HashToken(completePasswordResetDto.Token);
        var userToken = await userTokenRepository.GetActiveTokenByHashWithUserAsync(hashedToken, stoppingToken);

        if (userToken is null)
        {
            logger.LogWarning("[{Source}]: No active UserToken was found by hash.", Source);
            return Result<string>.Failure(StatusCodes.Status404NotFound);
        }

        if (userToken.UserTokenType is not UserTokenType.PasswordReset)
        {
            logger.LogWarning("[{Source}]: UserToken type is invalid for password reset.", Source);
            return Result<string>.Failure(StatusCodes.Status400BadRequest, ErrorType.InvalidTokenType);
        }
        
        logger.LogInformation("[{Source}]: Resetting password for User with Username={Username}...", Source, userToken.User.Username);
        await userRepository.ResetPasswordAsync(userToken.User.Id, completePasswordResetDto.NewPassword, stoppingToken);
        await userTokenRepository.DeleteAsync(userToken.Id, stoppingToken);

        return Result<string>.Success(StatusCodes.Status200OK, "Password has been successfully reset.");
    }
}