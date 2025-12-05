namespace Backend.Application.Dtos.User;

public record CompletePasswordResetDto
{
    public required string Token { get; init; }
    public required string NewPassword { get; init; }
}