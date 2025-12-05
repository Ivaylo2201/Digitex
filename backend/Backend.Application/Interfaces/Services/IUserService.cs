using Backend.Application.Dtos.User;
using Backend.Domain.Common;
using Backend.Domain.Enums;

namespace Backend.Application.Interfaces.Services;

public interface IUserService
{
    Task<Result<string>> SignUpAsync(SignUpDto signUpDto, CancellationToken stoppingToken = default);
    Task<Result<(string Token, Role Role)>> CompleteAccountVerificationAsync(AccountVerificationDto accountVerificationDto, CancellationToken stoppingToken = default);
    Task<Result<(string Token, Role Role)>> SignInAsync(SignInDto signInDto, CancellationToken stoppingToken = default);
    Task<Result<string>> RequestPasswordResetAsync(RequestPasswordResetDto requestPasswordResetDto, CancellationToken stoppingToken = default);
    Task<Result<string>> CompletePasswordResetAsync(CompletePasswordResetDto completePasswordResetDto, CancellationToken stoppingToken = default);
}