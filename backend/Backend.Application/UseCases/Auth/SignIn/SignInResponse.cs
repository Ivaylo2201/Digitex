using Backend.Domain.Enums;

namespace Backend.Application.UseCases.Auth.SignIn;

public record SignInResponse
{
    public required string Token { get; init; }
    public required Role Role { get; init; }
}