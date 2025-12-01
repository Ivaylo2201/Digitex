using Backend.Application.Dtos.User;
using Backend.Domain.Common;
using Backend.Domain.Enums;

namespace Backend.Application.Interfaces.Services;

public interface IUserService
{
    Task<Result<(string, Role)>> SignInAsync(SignInDto signInDto, CancellationToken stoppingToken = default);
    Task<Result> SignUpAsync(SignUpDto signUpDto, CancellationToken stoppingToken = default);
    Task<Result> VerifyUserAsync(string token, CancellationToken stoppingToken = default);
}