using System.Net;
using Backend.Application.Extensions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Backend.Application.UseCases.Accounts.RequestPasswordReset;

public class RequestPasswordResetRequestHandler(
    ILogger<RequestPasswordResetRequestHandler> logger,
    IUserRepository userRepository,
    ITokenService tokenService,
    IUserTokenRepository userTokenRepository,
    IEmailSenderService emailSenderService,
    IUrlService urlService) : IRequestHandler<RequestPasswordResetRequest, Result<RequestPasswordResetResponse>>
{
    private const string Source = nameof(RequestPasswordResetRequestHandler);
    
    public async Task<Result<RequestPasswordResetResponse>> Handle(RequestPasswordResetRequest request, CancellationToken cancellationToken)
    {
        using (LogContext.PushProperty("Source", Source))
        {
            logger.LogRequestProcessingStart(nameof(RequestPasswordResetRequest));
        
            var user = await userRepository.GetOneByEmailAsync(request.Email, cancellationToken);

            if (user is null)
            {
                logger.LogWarning("User with Email={Email} was not found.", request.Email);
                return Result<RequestPasswordResetResponse>.Failure(HttpStatusCode.NotFound);
            }
        
            var rawToken = tokenService.GenerateToken();
            var hashedToken = tokenService.HashToken(rawToken);
            
            logger.LogDebug("Creating PasswordReset UserToken for User with Email={Email}...", user.Email);
            await userTokenRepository.CreateAsync(UserToken.Create(user, hashedToken, UserTokenType.PasswordReset), cancellationToken);
            
            logger.LogDebug("Sending password reset email to {Email}...", user.Email);
            await emailSenderService.SendPasswordResetEmailAsync(user, urlService.GetPasswordResetUrl(rawToken), cancellationToken);
            
            return Result<RequestPasswordResetResponse>.Success(HttpStatusCode.OK, new RequestPasswordResetResponse
            {
                Message = $"Visit {user.Email} to reset your password."
            });
        }
    }
}