namespace Backend.Application.Interfaces.Email;

public interface IEmailBuilderService
{
    string BuildAccountVerificationEmail(string username, string verificationUrl);
    string BuildPasswordResetEmail(string username, string passwordResetUrl);
}