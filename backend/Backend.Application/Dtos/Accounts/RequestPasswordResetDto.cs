namespace Backend.Application.Dtos.Accounts;

public record RequestPasswordResetDto
{
    public required string Email { get; init; }
}