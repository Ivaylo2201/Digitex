using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using FluentEmail.Core;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Common;

public class EmailSendingService(
    ILogger<EmailSendingService> logger,
    IFluentEmail fluentEmail,
    IEmailCryptoService emailCryptoService) : IEmailSendingService
{
    private const string Source = nameof(EmailSendingService);
    
    public async Task SendVerificationMailAsync(User user, CancellationToken stoppingToken = default)
    {
        const string subject = "Welcome to Digitex!";
        var body = GetEmailBody(user);
        
        logger.LogInformation("[{Source}]: Sending verification email to {Email}...", Source, user.Email);
        
        await fluentEmail
            .To(user.Email, user.Username)
            .Subject(subject)
            .Body(body)
            .SendAsync();
    }

    private string GetEmailBody(User user)
    {
        var encryptedEmail = emailCryptoService.Encrypt(user.Email);
        
        logger.LogInformation("[{Source}]: Building verification email body...", Source);
        
        logger.LogInformation("[{Source}]: Encrypted email: {Email}", Source, encryptedEmail);
        
        return $"<div>Visit here to verify your account: {encryptedEmail}</div>";
    }
}