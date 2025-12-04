using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Services;

public interface IEmailSendingService
{
    Task SendVerificationEmailAsync(User user, string token, CancellationToken stoppingToken = default);
}