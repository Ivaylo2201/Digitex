using Backend.Domain.Enums;

namespace Backend.Domain.Common;

public class Result
{
    public readonly bool IsSuccess;
    public readonly ErrorObject? ErrorObject;
    public readonly int StatusCode;
    
    protected Result(int statusCode, ErrorObject? errorObject)
    {
        IsSuccess = statusCode is >= 200 and < 300;  
        ErrorObject = errorObject;
        StatusCode = statusCode;
    }

    public static Result Success(int statusCode)
        => new(statusCode, null);
    
    public static Result Failure(int statusCode, ErrorType? errorType = null, object? details = null) 
        => new(statusCode, ErrorObject.Construct(statusCode, errorType, details));
}

public class Result<T> : Result
{
    public readonly T? Value;
    
    private Result(int statusCode, T? value, ErrorObject? errorObject) : base(statusCode, errorObject)
    {
        Value = value;
    }
    
    public static Result<T> Success(int statusCode, T value)
        => new(statusCode, value, null);

    public new static Result<T> Failure(int statusCode, ErrorType? errorType = null, object? details = null) 
        => new(statusCode, default, ErrorObject.Construct(statusCode, errorType, details));
}