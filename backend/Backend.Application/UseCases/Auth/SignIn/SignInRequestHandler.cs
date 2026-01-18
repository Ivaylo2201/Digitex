using System.Net;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Auth.SignIn;

public class SignInRequestHandler(
    ILogger<SignInRequestHandler> logger,
    IUserRepository userRepository,
    IJwtService jwtService) : IRequestHandler<SignInRequest, Result<SignInResponse>>
{
    private const string Source = nameof(SignInRequestHandler);
    
    public async Task<Result<SignInResponse>> Handle(SignInRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetOneByCredentialsAsync(request.Email, request.Password, cancellationToken);

        return user is null ?
            Result<SignInResponse>.Failure(HttpStatusCode.BadRequest) :
            Result<SignInResponse>.Success(HttpStatusCode.OK, new SignInResponse
            {
                Token = jwtService.GenerateToken(user),
                Role = user.Role
            });
    }
}