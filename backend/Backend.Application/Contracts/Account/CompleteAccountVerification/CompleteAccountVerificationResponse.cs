using Backend.Domain.Enums;

namespace Backend.Application.Contracts.Account.CompleteAccountVerification;

public record CompleteAccountVerificationResponse
{
    public required string Token { get; init; }
    public required Role Role { get; init; }
}