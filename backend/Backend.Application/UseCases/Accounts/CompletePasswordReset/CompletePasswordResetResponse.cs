namespace Backend.Application.UseCases.Accounts.CompletePasswordReset;

public record CompletePasswordResetResponse
{
    public required string Message { get; init; }
}