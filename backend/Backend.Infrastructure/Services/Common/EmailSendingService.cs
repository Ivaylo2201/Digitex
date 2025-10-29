using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using FluentEmail.Core;

namespace Backend.Infrastructure.Services.Common;

public class EmailSendingService(IFluentEmail fluentEmail, IEmailCryptoService emailCryptoService) : IEmailSendingService
{
    public async Task SendWelcomeEmailAsync(User user, CancellationToken stoppingToken = default)
    {
        await fluentEmail
            .To(user.Email, user.Username)
            .Subject("Welcome to MyApp!")
            .Body(GetEmailBody(user))
            .SendAsync();
    }

    private string GetEmailBody(User user)
    {
        var encryptedEmail = emailCryptoService.Encrypt(user.Email);
        return $"<div>Visit here to verify your account: {encryptedEmail}</div>";
    }
}