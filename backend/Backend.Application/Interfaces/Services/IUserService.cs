using Backend.Application.Dtos.User;
using Backend.Domain.Common;
using Backend.Domain.Enums;

namespace Backend.Application.Interfaces.Services;

public interface IUserService
{
    Task<Result<(string Token, Role Role)>> SignInAsync(SignInDto signInDto, CancellationToken stoppingToken = default);
    Task<Result<string>> SignUpAsync(SignUpDto signUpDto, CancellationToken stoppingToken = default);
    Task<Result<(string Token, Role Role)>> VerifyUserAsync(VerifyUserDto verifyUserDto, CancellationToken stoppingToken = default);
    Task<Result> ResetPasswordAsync(ResetPasswordDto resetPasswordDto, CancellationToken stoppingToken = default);
}