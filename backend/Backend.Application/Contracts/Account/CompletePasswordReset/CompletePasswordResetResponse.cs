namespace Backend.Application.Contracts.Account.CompletePasswordReset;

public record CompletePasswordResetResponse
{
    public string? Message { get; init; }
}