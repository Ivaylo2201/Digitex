namespace Backend.Application.Interfaces.Services;

public interface IEmailBuilderService
{
    string BuildAccountVerificationEmail(string username, string verificationUrl);
    string BuildPasswordResetEmail(string resetLink);
}