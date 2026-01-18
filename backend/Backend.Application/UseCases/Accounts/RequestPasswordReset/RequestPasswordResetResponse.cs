namespace Backend.Application.UseCases.Accounts.RequestPasswordReset;

public record RequestPasswordResetResponse
{
    public required string Message { get; init; }
}