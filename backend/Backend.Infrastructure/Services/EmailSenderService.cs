using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using FluentEmail.Core;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services;

public class EmailSenderService(
    ILogger<EmailSenderService> logger,
    IFluentEmail fluentEmail,
    IEmailBuilderService emailBuilderService) : IEmailSenderService
{
    private const string Source = nameof(EmailSenderService);

    public async Task SendAccountVerificationEmailAsync(User user, string accountVerificationUrl, CancellationToken stoppingToken = default)
    {
        try
        {
            logger.LogInformation("[{Source}]: Sending account verification email to {Email}...", Source, user.Email);

            await SendEmailAsync(
                user,
                "Verify Your Account",
                emailBuilderService.BuildAccountVerificationEmail(user.Username, accountVerificationUrl),
                stoppingToken);
        }
        catch (Exception ex)
        {

        }
    }

    public async Task SendPasswordResetEmailAsync(User user, string passwordResetUrl, CancellationToken stoppingToken = default)
    {
        try
        {
            logger.LogInformation("[{Source}]: Sending password reset email to {Email}...", Source, user.Email);
            
            await SendEmailAsync(
                user,
                "Reset Your Password",
                emailBuilderService.BuildPasswordResetEmail(user.Username, passwordResetUrl),
                stoppingToken);
        }
        catch (Exception ex)
        {

        }
    }

    private async Task SendEmailAsync(User user, string subject, string body, CancellationToken stoppingToken)
    {
        await fluentEmail
            .To(user.Email, user.Username)
            .Subject($"[DIGITEX] {subject}")
            .Body(body, isHtml: true)
            .SendAsync(stoppingToken);
    }
}