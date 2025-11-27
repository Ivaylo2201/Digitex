using Backend.Domain.Enums;
using Backend.Domain.Extensions;

namespace Backend.Domain.Common;

public class Result
{
    public readonly bool IsSuccess;
    public readonly ErrorObject? ErrorObject;
    public readonly int? StatusCode;

    protected Result(bool isSuccess, int? statusCode, ErrorObject? errorObject)
    {
        IsSuccess = isSuccess;
        ErrorObject = errorObject;
        StatusCode = statusCode;
    }

    public static Result Success() => new(true, null, null);

    public static Result Failure(ErrorType errorType, int? statusCode = null, object? details = null) => new(false, statusCode, new ErrorObject
    {
        Message = errorType.ToMessage(),
        Details = details
    });
}

public class Result<T> : Result
{
    public readonly T? Value;

    private Result(bool isSuccess, T? value, int? statusCode, ErrorObject? errorObject) : base(isSuccess, statusCode, errorObject)
    {
        Value = value;
    }

    public static Result<T> Success(T value) => new(true, value, null, null);

    public new static Result<T> Failure(ErrorType errorType, int? statusCode = null, object? details = null) => new(false, default, statusCode, new ErrorObject
    {
        Message = errorType.ToMessage(),
        Details = details   
    });
}