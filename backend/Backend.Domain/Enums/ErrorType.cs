namespace Backend.Domain.Enums;

public enum ErrorType
{
    DatabaseError,
    InvalidCredentials,
    ValidationFailed,
    CryptographyError,
    OutOfStock,
    InvalidWebhookSecret,
    PaymentFailed,
    General
}