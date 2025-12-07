using Backend.Application.Dtos.User;
using Backend.Domain.Common;
using Backend.Domain.Enums;

namespace Backend.Application.Interfaces;

public interface IAuthenticationService
{
    Task<Result<string>> SignUpAsync(SignUpDto signUpDto, CancellationToken stoppingToken = default);
    Task<Result<(string Token, Role Role)>> SignInAsync(SignInDto signInDto, CancellationToken stoppingToken = default);
}