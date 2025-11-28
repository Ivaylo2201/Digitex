using Backend.Domain.Enums;

namespace Backend.Domain.Extensions;

public static class ErrorTypeExtensions
{
    public static string ToMessage(this ErrorType errorType) => errorType switch
    {
        ErrorType.EmailTaken => "Email already taken.",
        ErrorType.InvalidCredentials => "Invalid credentials.",
        ErrorType.ValidationFailed => "Validation failed.",
        ErrorType.CryptographyError => "Cryptography operation failed.",
        ErrorType.OutOfStock => "Product is out of stock.",
        ErrorType.InvalidWebhookSecret => "Improperly configured webhook secret.",
        ErrorType.PaymentFailed => "Payment failed.",
        _ => "An unknown error has occurred."
    };
}