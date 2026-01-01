using Backend.Application.Contracts.Authentication.SignIn;
using Backend.Application.Contracts.Authentication.SignUp;
using Backend.Domain.Common;
using Backend.Domain.Enums;

namespace Backend.Application.Interfaces;

public interface IAuthenticationService
{
    Task<Result<string>> SignUpAsync(SignUpRequest signUpRequest, CancellationToken stoppingToken = default);
    Task<Result<(string Token, Role Role)>> SignInAsync(SignInRequest signInRequest, CancellationToken stoppingToken = default);
}