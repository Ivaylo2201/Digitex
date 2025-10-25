namespace Backend.Application.DTOs.User;

public class SignInUserDto
{
    public required string Username { get; init; }
    public required string Password { get; init; }
}