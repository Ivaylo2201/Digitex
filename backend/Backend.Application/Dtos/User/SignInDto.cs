namespace Backend.Application.Dtos.User;

public class SignInDto
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}