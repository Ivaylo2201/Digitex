using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Services;

public interface IEmailSendingService
{
    Task SendVerificationMailAsync(User user, CancellationToken stoppingToken = default);
}