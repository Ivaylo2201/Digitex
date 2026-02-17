using System.Net;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Backend.Application.UseCases.Auth.SignIn;

public class SignInRequestHandler(
    ILogger<SignInRequestHandler> logger,
    IUserRepository userRepository,
    IJwtService jwtService) : IRequestHandler<SignInRequest, Result<SignInResponse>>
{
    private const string Source = nameof(SignInRequestHandler);
    
    public async Task<Result<SignInResponse>> Handle(SignInRequest request, CancellationToken cancellationToken)
    {
        using (LogContext.PushProperty("Source", Source))
        {
            logger.LogInformation("Getting user by credentials...");
            var user = await userRepository.GetOneByCredentialsAsync(request.Email, request.Password, cancellationToken);

            logger.LogInformation("Generating JWT...");
            return user is null ?
                Result<SignInResponse>.Failure(HttpStatusCode.BadRequest) :
                Result<SignInResponse>.Success(HttpStatusCode.OK, new SignInResponse
                {
                    Token = jwtService.GenerateToken(user),
                    Role = user.Role
                });
        }
    }
}