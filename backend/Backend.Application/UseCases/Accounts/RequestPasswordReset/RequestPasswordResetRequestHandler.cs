using System.Net;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

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
        logger.LogInformation("[{Source}]: Requesting password reset for User with Email={Email}...", Source, request.Email);
        
        var user = await userRepository.GetOneByEmailAsync(request.Email, cancellationToken);

        if (user is null)
        {
            logger.LogWarning("[{Source}]: User with Email={Email} was not found.", Source, request.Email);
            return Result<RequestPasswordResetResponse>.Failure(HttpStatusCode.NotFound);
        }
        
        var rawToken = tokenService.GenerateToken();
        var hashedToken = tokenService.HashToken(rawToken);
        await userTokenRepository.CreateAsync(UserToken.Create(user, hashedToken, UserTokenType.PasswordReset), cancellationToken);
        
        await emailSenderService.SendPasswordResetEmailAsync(user, urlService.GetPasswordResetUrl(rawToken), cancellationToken);
        return Result<RequestPasswordResetResponse>.Success(HttpStatusCode.OK, new RequestPasswordResetResponse
        {
            Message = $"Visit {user.Email} to reset your password."
        });
    }
}