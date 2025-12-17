namespace Backend.Application.Dtos.Authentication;

public record SignUpDto
{
    public required string Username { get; init; }
    public required string Email { get; init; }   
    public required string Password { get; init; }
    public required string PasswordConfirmation { get; init; }
}