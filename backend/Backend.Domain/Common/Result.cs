using Backend.Domain.Enums;

namespace Backend.Domain.Common;

public class Result<T>
{
    public readonly bool IsSuccess;
    public readonly ErrorObject? ErrorObject;
    public readonly T? Value;

    private Result(bool isSuccess, T? value, ErrorObject? errorObject)
    {
        IsSuccess = isSuccess;
        Value = value;
        ErrorObject = errorObject;
    }
    
    public static Result<T> Success(T value) => new(true, value, null);
    
    public static Result<T> Failure(ErrorType errorType) => new(false, default, new ErrorObject
    {
        Message = errorType switch
        {
            ErrorType.NotFound => "Resource not found.",
            ErrorType.Forbidden => "Access forbidden.",
            ErrorType.Unauthorized => "Unauthorized access.",
            _ => "An unknown error occurred."
        }
    });
}