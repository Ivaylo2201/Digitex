using System.Net;
using Backend.Domain.Enums;

namespace Backend.Domain.Common;

public class ErrorObject
{
    public string Message { get; init; }
    public object? Details { get; init; }

    private ErrorObject(string message, object? details = null)
    {
        Message = message;
        Details = details;
    }

    public static ErrorObject Construct(int statusCode, ErrorType? errorType = null, object? details = null)
        => new(statusCode switch
        {
            (int)HttpStatusCode.NotFound => "Resource not found.",
            (int)HttpStatusCode.Unauthorized => "Unauthorized access.",
            (int)HttpStatusCode.Forbidden => "Access forbidden.",
            _ => errorType switch
            {
                ErrorType.DatabaseError => "Database operation failed.",
                ErrorType.InvalidCredentials => "Invalid credentials.",
                ErrorType.ValidationFailed => "Validation failed.",
                ErrorType.CryptographyError => "Cryptography operation failed.",
                ErrorType.OutOfStock => "Product is out of stock.",
                ErrorType.InvalidWebhookSecret => "Improperly configured webhook secret.",
                ErrorType.PaymentFailed => "Payment failed.",
                _ => "An unknown error has occurred."
            }
        }, details);
}