using System.Net;
using Backend.Application.Extensions;
using Backend.Application.Interfaces.Email;
using Backend.Application.Interfaces.Tokens;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Auth.SignUp;

public class SignUpRequestHandler(
    ILogger<SignUpRequestHandler> logger,
    IUserRepository userRepository,
    ITokenService tokenService,
    IUserTokenRepository userTokenRepository,
    IEmailSenderService emailSenderService,
    IUrlService urlService) : IRequestHandler<SignUpRequest, Result<SignUpResponse>>
{
    private const string Source = nameof(SignUpRequestHandler);
    
    public async Task<Result<SignUpResponse>> Handle(SignUpRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await userRepository.CreateAsync(new User
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                Cart = new Cart()
            }, cancellationToken);
            
            await RequestAccountVerificationAsync(user, cancellationToken);
            
            return Result<SignUpResponse>.Success(HttpStatusCode.OK, new SignUpResponse
            {
                Message = $"Visit {user.Email} to verify your account."
            });
        }
        catch (Exception ex)
        {
            logger.LogException(Source, ex, "creating user or account verification token");
            return Result<SignUpResponse>.Failure(HttpStatusCode.InternalServerError);       
        }
    }
    
    private async Task RequestAccountVerificationAsync(User user, CancellationToken stoppingToken)
    {
        var rawToken = tokenService.GenerateToken();
        var hashedToken = tokenService.HashToken(rawToken);
            
        await userTokenRepository.CreateAsync(UserToken.Create(user, hashedToken, UserTokenType.AccountVerification), stoppingToken);
        await emailSenderService.SendAccountVerificationEmailAsync(user, urlService.GetAccountVerificationUrl(rawToken), stoppingToken);
    }
}