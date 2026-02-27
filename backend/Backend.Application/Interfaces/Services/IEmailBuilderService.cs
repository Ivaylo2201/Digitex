using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Services;

public interface IEmailBuilderService
{
    string BuildAccountVerificationEmail(string username, string verificationUrl);
    string BuildPasswordResetEmail(string username, string passwordResetUrl);
    string BuildOrderConfirmationEmail(string username, Order order);
}