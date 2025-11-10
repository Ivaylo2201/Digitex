namespace Backend.Domain.Enums;

public enum ErrorType
{
    NotFound,
    Unauthorized,
    Forbidden,
    EmailTaken,
    InvalidCredentials,
    ValidationFailed,
    CryptographyError
}