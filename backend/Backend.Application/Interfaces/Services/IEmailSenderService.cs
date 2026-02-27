using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Services;

public interface IEmailSenderService
{
    Task SendAccountVerificationEmailAsync(User user, string verificationUrl, CancellationToken cancellationToken = default);
    Task SendPasswordResetEmailAsync(User user, string passwordResetUrl, CancellationToken cancellationToken = default);
    Task SendOrderConfirmationEmailAsync(User user, Order order, CancellationToken cancellationToken = default);
}