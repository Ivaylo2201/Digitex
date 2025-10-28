using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Services;

public interface IEmailSendingService
{
    Task SendWelcomeEmailAsync(User user, CancellationToken stoppingToken = default);
}