using Backend.Domain.Enums;

namespace Backend.Domain.Extensions;

public static class ErrorTypeExtensions
{
    public static string ToMessage(this ErrorType errorType) => errorType switch
    {
        ErrorType.NotFound => "Resource not found.",
        ErrorType.Forbidden => "Access forbidden.",
        ErrorType.Unauthorized => "Unauthorized access.",
        ErrorType.UsernameTaken => "Username already taken.",
        ErrorType.InvalidCredentials => "Invalid credentials.",
        ErrorType.ValidationFailed => "Validation failed.",
        _ => "An unknown error occurred."
    };
}