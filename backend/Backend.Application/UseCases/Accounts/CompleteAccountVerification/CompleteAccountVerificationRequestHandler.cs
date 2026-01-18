using System.Net;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Accounts.CompleteAccountVerification;

public class CompleteAccountVerificationRequestHandler(
    ILogger<CompleteAccountVerificationRequestHandler> logger,
    ITokenService tokenService,
    IUserTokenRepository userTokenRepository,
    IUserRepository userRepository,
    IJwtService jwtService) : IRequestHandler<CompleteAccountVerificationRequest, Result<CompleteAccountVerificationResponse>>
{
    private const string Source = nameof(CompleteAccountVerificationRequestHandler);
    
    public async Task<Result<CompleteAccountVerificationResponse>> Handle(CompleteAccountVerificationRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{Source}]: Completing account verification...", Source);
        
        var hashedToken = tokenService.HashToken(request.Token);
        var userToken = await userTokenRepository.GetActiveTokenByHashWithUserAsync(hashedToken, cancellationToken);
        
        if (userToken is null)
        {
            logger.LogWarning("[{Source}]: No active UserToken was found by hash.", Source);
            return Result<CompleteAccountVerificationResponse>.Failure(HttpStatusCode.NotFound);
        }

        if (userToken.UserTokenType is not UserTokenType.AccountVerification)
        {
            logger.LogWarning("[{Source}]: UserToken type is invalid for account verification.", Source);
            return Result<CompleteAccountVerificationResponse>.Failure(HttpStatusCode.BadRequest);
        }
        
        logger.LogInformation("[{Source}]: Verifying User with Username={Username}...", Source, userToken.User.Username);
        var user = await userRepository.VerifyUserAsync(userToken.User.Id, cancellationToken);
        
        await userTokenRepository.DeleteAsync(userToken.Id, cancellationToken);
        
        return user is null ? 
            Result<CompleteAccountVerificationResponse>.Failure(HttpStatusCode.NotFound) : 
            Result<CompleteAccountVerificationResponse>.Success(HttpStatusCode.OK, new CompleteAccountVerificationResponse
            {
                Token = jwtService.GenerateToken(user),
                Role = user.Role
            });
    }
}