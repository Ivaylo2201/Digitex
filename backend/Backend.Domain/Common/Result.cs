using Backend.Domain.Enums;

namespace Backend.Domain.Common;

public class Result<T>
{
    public readonly bool IsSuccess;
    public readonly string? ErrorMessage;
    public readonly T? Value;

    private Result(bool isSuccess, T? value, string? errorMessage)
    {
        IsSuccess = isSuccess;
        Value = value;
        ErrorMessage = errorMessage;
    }
    
    public static Result<T> Success(T value) => new(true, value, null);
    
    public static Result<T> Failure(ErrorType errorType) => new(false, default, errorType switch
    {
        ErrorType.NotFound => "Resource not found.",
        ErrorType.Forbidden => "Access forbidden.",
        ErrorType.Unauthorized => "Unauthorized access.",
        _ => "An error occurred."
    });
}