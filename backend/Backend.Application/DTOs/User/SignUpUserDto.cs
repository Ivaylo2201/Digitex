namespace Backend.Application.DTOs.User;

public class SignUpUserDto
{
    public required string Username { get; init; }
    public required string Password { get; init; }
    public required string PasswordConfirmation { get; init; }
}