namespace Backend.Domain.Enums;

public enum ErrorType
{
    NotFound,
    Unauthorized,
    Forbidden,
    UsernameTaken,
    InvalidCredentials,
    ValidationFailed
}