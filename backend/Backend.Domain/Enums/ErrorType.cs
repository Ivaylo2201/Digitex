namespace Backend.Domain.Enums;

public enum ErrorType
{
    EmailTaken,
    InvalidCredentials,
    ValidationFailed,
    CryptographyError,
    OutOfStock,
    InvalidWebhookSecret,
    PaymentFailed,
    General
}