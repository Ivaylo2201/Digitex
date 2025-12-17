namespace Backend.Application.Dtos.Accounts;

public record CompletePasswordResetDto
{
    public required string Token { get; init; }
    public required string NewPassword { get; init; }
}