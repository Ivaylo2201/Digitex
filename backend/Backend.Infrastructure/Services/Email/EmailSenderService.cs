using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Infrastructure.Extensions;
using FluentEmail.Core;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Email;

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
            
            await fluentEmail
                .To(user.Email, user.Username)
                .Subject("[DIGITEX] Verify Your Account")
                .Body(emailBuilderService.BuildAccountVerificationEmail(user.Username, accountVerificationUrl), isHtml: true)
                .SendAsync(stoppingToken);
        }
        catch (Exception ex)
        {
            logger.LogException(Source, ex, $"sending account verification email to {user.Email}");
        }
    }

    public async Task SendPasswordResetEmailAsync(User user, string passwordResetUrl, CancellationToken stoppingToken = default)
    {
        try
        {
            logger.LogInformation("[{Source}]: Sending password reset email to {Email}...", Source, user.Email);
            
            await fluentEmail
                .To(user.Email, user.Username)
                .Subject("[DIGITEX] Reset Your Password")
                .Body(emailBuilderService.BuildPasswordResetEmail(user.Username, passwordResetUrl), isHtml: true)
                .SendAsync(stoppingToken);
        }
        catch (Exception ex)
        {
            logger.LogException(Source, ex, $"sending password reset email to {user.Email}");
        }
    }
}