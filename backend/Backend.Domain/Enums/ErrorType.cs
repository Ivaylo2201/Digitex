namespace Backend.Domain.Enums;

public enum ErrorType
{
    DatabaseError,
    InvalidTokenType,
    InvalidCredentials,
    ValidationFailed,
    CryptographyError,
    OutOfStock,
    InvalidWebhookSecret,
    PaymentFailed,
    General
}