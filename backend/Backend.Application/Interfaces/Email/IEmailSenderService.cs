using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Email;

public interface IEmailSenderService
{
    Task SendAccountVerificationEmailAsync(User user, string verificationUrl, CancellationToken stoppingToken = default);
    Task SendPasswordResetEmailAsync(User user, string passwordResetUrl, CancellationToken stoppingToken = default);
}