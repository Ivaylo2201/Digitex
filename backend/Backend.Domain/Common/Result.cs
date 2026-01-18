using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Backend.Domain.Common;

public class Result<TValue>
{
    public readonly int StatusCode;
    public readonly TValue? Value;
    public readonly string? ErrorMessage;

    private Result(int statusCode, TValue? value, string? errorMessage)
    {
        StatusCode = statusCode;
        Value = value;
        ErrorMessage = errorMessage;
    }
    
    [MemberNotNullWhen(true, nameof(Value))]
    public bool IsSuccess => StatusCode is >= 200 and < 300 && ErrorMessage is null && Value is not null;

    public static Result<TValue> Success(HttpStatusCode httpStatusCode, TValue value)
        => new((int)httpStatusCode, value, null);

    public static Result<TValue> Failure(HttpStatusCode httpStatusCode)
        => new((int)httpStatusCode, default, httpStatusCode switch
        {
            HttpStatusCode.NotFound => "Resource not found.",
            HttpStatusCode.Unauthorized => "Unauthorized access.",
            HttpStatusCode.Forbidden => "Access forbidden.",
            _ => "Internal server error."
        });
}