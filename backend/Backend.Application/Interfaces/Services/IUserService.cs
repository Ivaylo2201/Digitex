using Backend.Application.DTOs.User;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Services;

public interface IUserService
{
    Task<Result<string>> SignInAsync(SignInDto signInDto, CancellationToken stoppingToken = default);
    Task<Result> SignUpAsync(SignUpDto signUpDto, CancellationToken stoppingToken = default);
    Task<Result> VerifyUserAsync(string token, CancellationToken stoppingToken = default);
}