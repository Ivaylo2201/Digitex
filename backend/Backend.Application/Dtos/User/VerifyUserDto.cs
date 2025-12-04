namespace Backend.Application.Dtos.User;

public record VerifyUserDto
{
    public required string Token { get; init; }
}