using Backend.Application.Dtos.Accounts;
using Backend.Domain.Common;
using Backend.Domain.Enums;

namespace Backend.Application.Interfaces;

public interface IAccountService
{
    Task<Result<(string Token, Role Role)>> CompleteAccountVerificationAsync(CompleteAccountVerificationDto completeAccountVerificationDto, CancellationToken stoppingToken = default);
    Task<Result<string>> RequestPasswordResetAsync(RequestPasswordResetDto requestPasswordResetDto, CancellationToken stoppingToken = default);
    Task<Result<string>> CompletePasswordResetAsync(CompletePasswordResetDto completePasswordResetDto, CancellationToken stoppingToken = default);
}