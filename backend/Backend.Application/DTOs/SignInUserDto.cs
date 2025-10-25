namespace Backend.Application.DTOs;

public class SignInUserDto
{
    public required string Username { get; init; }
    public required string Password { get; init; }
}