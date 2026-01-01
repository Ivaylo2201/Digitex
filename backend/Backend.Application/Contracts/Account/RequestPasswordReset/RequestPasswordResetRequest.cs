namespace Backend.Application.Contracts.Account.RequestPasswordReset;

public record RequestPasswordResetRequest
{
    public required string Email { get; init; }
}