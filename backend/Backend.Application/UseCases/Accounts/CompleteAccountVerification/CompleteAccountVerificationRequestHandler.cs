using System.Net;
using Backend.Application.Extensions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

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
        using (LogContext.PushProperty("Source", Source))
        {
            logger.LogRequestProcessingStart(nameof(CompleteAccountVerificationRequest));
        
            var hashedToken = tokenService.HashToken(request.Token);
            var userToken = await userTokenRepository.GetActiveTokenByHashWithUserAsync(hashedToken, cancellationToken);
        
            if (userToken is null)
            {
                logger.LogWarning("[{Source}]: No active UserToken was found by hash.", Source);
                return Result<CompleteAccountVerificationResponse>.Failure(HttpStatusCode.NotFound);
            }

            if (userToken.UserTokenType is not UserTokenType.AccountVerification)
            {
                logger.LogWarning("UserToken type is invalid for account verification.");
                return Result<CompleteAccountVerificationResponse>.Failure(HttpStatusCode.BadRequest);
            }
        
            logger.LogDebug("Verifying User with Username={Username}...", userToken.User.Username);
            var user = await userRepository.VerifyUserAsync(userToken.User.Id, cancellationToken);
        
            logger.LogDebug("Deleting UserToken with Id={Id}...", userToken.Id);
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
}