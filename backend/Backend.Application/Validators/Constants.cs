namespace Backend.Application.Validators;

public static class Constants
{
    public const int UsernameMinLength = 3;
    public const int UsernameMaxLength = 25;
    public const int PasswordMinLength = 8;
    public const string PasswordRegex = @"^(?=.*[A-Za-z])(?=.*\d).+$";
    public const string EmailRequired = "Email is required.";
    public const string EmailInvalid = "Invalid email address.";
    public const string UsernameRequired = "Username is required.";
    public const string UsernameTooShort = "Username is too short.";
    public const string UsernameTooLong = "Username is too long.";
    public const string PasswordRequired = "Password is required.";
    public const string PasswordTooShort = "Password is too short.";
    public const string PasswordRegexError = "Password does not meet complexity requirements.";
    public const string PasswordMismatch = "Passwords do not match.";
    public const string PasswordContainsUsername = "Password should not contain the username.";
}