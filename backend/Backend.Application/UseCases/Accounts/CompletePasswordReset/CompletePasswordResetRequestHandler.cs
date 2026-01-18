using System.Net;
using Backend.Application.Interfaces.Tokens;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Accounts.CompletePasswordReset;

public class CompletePasswordResetRequestHandler(
    ILogger<CompletePasswordResetRequestHandler> logger,
    ITokenService tokenService,
    IUserTokenRepository userTokenRepository,
    IUserRepository userRepository) : IRequestHandler<CompletePasswordResetRequest, Result<CompletePasswordResetResponse>>
{
    private const string Source = nameof(CompletePasswordResetRequestHandler);
    
    public async Task<Result<CompletePasswordResetResponse>> Handle(CompletePasswordResetRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{Source}]: Completing password reset...", Source);
        
        var hashedToken = tokenService.HashToken(request.Token);
        var userToken = await userTokenRepository.GetActiveTokenByHashWithUserAsync(hashedToken, cancellationToken);

        if (userToken is null)
        {
            logger.LogWarning("[{Source}]: No active UserToken was found by hash.", Source);
            return Result<CompletePasswordResetResponse>.Failure(HttpStatusCode.NotFound);
        }

        if (userToken.UserTokenType is not UserTokenType.PasswordReset)
        {
            logger.LogWarning("[{Source}]: UserToken type is invalid for password reset.", Source);
            return Result<CompletePasswordResetResponse>.Failure(HttpStatusCode.BadRequest);
        }
        
        logger.LogInformation("[{Source}]: Resetting password for User with Username={Username}...", Source, userToken.User.Username);
        await userRepository.ResetPasswordAsync(userToken.User.Id, request.NewPassword, cancellationToken);
        await userTokenRepository.DeleteAsync(userToken.Id, cancellationToken);

        return Result<CompletePasswordResetResponse>.Success(HttpStatusCode.OK, new CompletePasswordResetResponse
        {
            Message = "Password has been successfully reset."
        });
    }
}