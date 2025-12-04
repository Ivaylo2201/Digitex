using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using FluentEmail.Core;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Common;

public class EmailSendingService(
    ILogger<EmailSendingService> logger,
    IFluentEmail fluentEmail,
    IEmailBuilderService emailBuilderService,
    string frontendUrl) : IEmailSendingService
{
    private const string Source = nameof(EmailSendingService);

    public async Task SendVerificationEmailAsync(User user, string token, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Sending verification email to {Email}...", Source, user.Email);
        const string subject = "Welcome to Digitex!";

        try
        {
            await fluentEmail
                .To(user.Email, user.Username)
                .Subject(subject)
                .Body(GetAccountVerificationEmailBody(user, token), isHtml: true)
                .SendAsync(stoppingToken);

            logger.LogInformation("[{Source}]: Verification email sent successfully to {Email}.", Source, user.Email);
        }
        catch (Exception ex)
        {
            logger.LogError("[{Source}]: Failed to send verification email to {Email}. Exception message - {Exception}", Source, user.Email, ex.Message);
        }
    }

    private string GetAccountVerificationEmailBody(User user, string token)
        => emailBuilderService.BuildAccountVerificationEmail(user.Username, $"{frontendUrl}/auth/verify?token={token}");
}