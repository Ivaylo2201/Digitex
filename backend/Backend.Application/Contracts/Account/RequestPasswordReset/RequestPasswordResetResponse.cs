namespace Backend.Application.Contracts.Account.RequestPasswordReset;

public record RequestPasswordResetResponse
{
    public string? Message { get; init; }
}