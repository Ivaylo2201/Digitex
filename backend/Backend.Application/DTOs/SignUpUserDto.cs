namespace Backend.Application.DTOs;

public class SignUpUserDto
{
    public required string Username { get; init; }
    public required string Password { get; init; }
    public required string PasswordConfirmation { get; init; }
}