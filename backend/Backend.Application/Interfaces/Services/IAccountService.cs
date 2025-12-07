using Backend.Application.Dtos.User;
using Backend.Domain.Common;
using Backend.Domain.Enums;

namespace Backend.Application.Interfaces.Services;

public interface IAccountService
{
    Task<Result<(string Token, Role Role)>> CompleteAccountVerificationAsync(AccountVerificationDto accountVerificationDto, CancellationToken stoppingToken = default);
    Task<Result<string>> RequestPasswordResetAsync(RequestPasswordResetDto requestPasswordResetDto, CancellationToken stoppingToken = default);
    Task<Result<string>> CompletePasswordResetAsync(CompletePasswordResetDto completePasswordResetDto, CancellationToken stoppingToken = default);
}