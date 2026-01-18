namespace Backend.Application.UseCases.Auth.SignUp;

public record SignUpResponse
{
    public required string Message { get; init; }
}