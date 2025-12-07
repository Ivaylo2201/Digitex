using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Infrastructure.Extensions;
using FluentEmail.Core;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Email;

public class EmailSendingService(
    ILogger<EmailSendingService> logger,
    IFluentEmail fluentEmail,
    IEmailBuilderService emailBuilderService) : IEmailSendingService
{
    private const string Source = nameof(EmailSendingService);

    public async Task SendAccountVerificationEmailAsync(User user, string accountVerificationUrl, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Sending verification email to {Email}...", Source, user.Email);
        const string subject = "Welcome to Digitex!";

        try
        {
            await fluentEmail
                .To(user.Email, user.Username)
                .Subject(subject)
                .Body(emailBuilderService.BuildAccountVerificationEmail(user.Username, accountVerificationUrl), isHtml: true)
                .SendAsync(stoppingToken);

            logger.LogInformation("[{Source}]: Verification email sent successfully to {Email}.", Source, user.Email);
        }
        catch (Exception ex)
        {
            logger.LogException(Source, ex, $"sending verification email to {user.Email}");
        }
    }

    public async Task SendPasswordResetEmailAsync(User user, string passwordResetUrl, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Sending password reset email to {Email}...", Source, user.Email);
        const string subject = "Reset password for you Digitex account.";

        try
        {
            await fluentEmail
                .To(user.Email, user.Username)
                .Subject(subject)
                .Body(emailBuilderService.BuildPasswordResetEmail(user.Username, passwordResetUrl), isHtml: true)
                .SendAsync(stoppingToken);
        }
        catch (Exception ex)
        {
            logger.LogException(Source, ex, $"sending password reset email to {user.Email}");
        }
    }
}