namespace Backend.Application.Contracts.Authentication.SignIn;

public record SignInRequest
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}