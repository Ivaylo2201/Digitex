using Backend.Domain.Enums;
using Backend.Domain.Extensions;

namespace Backend.Domain.Common;

public class Result
{
    public readonly bool IsSuccess;
    public readonly ErrorObject? ErrorObject;

    protected Result(bool isSuccess, ErrorObject? errorObject)
    {
        IsSuccess = isSuccess;
        ErrorObject = errorObject;
    }

    public static Result Success() => new(true, null);

    public static Result Failure(ErrorType errorType, object? details = null) => new(false, new ErrorObject
    {
        Message = errorType.ToMessage(),
        Details = details
    });
}

public class Result<T> : Result
{
    public readonly T? Value;

    private Result(bool isSuccess, T? value, ErrorObject? errorObject) : base(isSuccess, errorObject)
    {
        Value = value;
    }

    public static Result<T> Success(T value) => new(true, value, null);

    public new static Result<T> Failure(ErrorType errorType, object? details = null) => new(false, default, new ErrorObject
    {
        Message = errorType.ToMessage(),
        Details = details   
    });
}