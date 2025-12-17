namespace Backend.Application.Dtos.Authentication;

public record SignInDto
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}