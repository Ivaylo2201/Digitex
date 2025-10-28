namespace Backend.Application.DTOs.User;

public class SignInDto
{
    public required string Username { get; init; }
    public required string Password { get; init; }
}