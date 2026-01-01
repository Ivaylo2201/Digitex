namespace Backend.Application.Contracts.Account.CompletePasswordReset;

public record CompletePasswordResetRequest
{
    public required string Token { get; init; }
    public required string NewPassword { get; init; }
}