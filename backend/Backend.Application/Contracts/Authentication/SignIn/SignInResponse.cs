using Backend.Domain.Enums;

namespace Backend.Application.Contracts.Authentication.SignIn;

public record SignInResponse
{
    public required string Token { get; init; }
    public required Role Role { get; init; }
}