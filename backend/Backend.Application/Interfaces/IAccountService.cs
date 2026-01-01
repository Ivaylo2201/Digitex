using Backend.Application.Contracts.Account.CompleteAccountVerification;
using Backend.Application.Contracts.Account.CompletePasswordReset;
using Backend.Application.Contracts.Account.RequestPasswordReset;
using Backend.Domain.Common;
using Backend.Domain.Enums;

namespace Backend.Application.Interfaces;

public interface IAccountService
{
    Task<Result<(string Token, Role Role)>> CompleteAccountVerificationAsync(CompleteAccountVerificationRequest completeAccountVerificationRequest, CancellationToken stoppingToken = default);
    Task<Result<string>> RequestPasswordResetAsync(RequestPasswordResetRequest requestPasswordResetRequest, CancellationToken stoppingToken = default);
    Task<Result<string>> CompletePasswordResetAsync(CompletePasswordResetRequest completePasswordResetRequest, CancellationToken stoppingToken = default);
}