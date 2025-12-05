namespace Backend.Application.Dtos.User;

public record AccountVerificationDto
{
    public required string Token { get; init; }
}