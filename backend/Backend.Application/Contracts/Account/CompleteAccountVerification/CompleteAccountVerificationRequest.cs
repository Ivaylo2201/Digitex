namespace Backend.Application.Contracts.Account.CompleteAccountVerification;

public record CompleteAccountVerificationRequest
{
    public required string Token { get; init; }
}