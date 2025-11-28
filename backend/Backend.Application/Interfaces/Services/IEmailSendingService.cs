using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Services;

public interface IEmailSendingService
{
    Task SendVerificationEmailAsync(User user, CancellationToken stoppingToken = default);
    Task SendOrderConfirmationEmailAsync(User user, CancellationToken stoppingToken = default);
}