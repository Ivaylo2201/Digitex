using System.Web;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using FluentEmail.Core;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Common;

public class EmailSendingService(
    ILogger<EmailSendingService> logger,
    IFluentEmail fluentEmail,
    IEmailCryptoService emailCryptoService,
    string frontendUrl) : IEmailSendingService
{
    private const string Source = nameof(EmailSendingService);

    public async Task SendVerificationMailAsync(User user, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Sending verification email to {Email}...", Source, user.Email);
        const string subject = "Welcome to Digitex!";

        try
        {
            await fluentEmail
                .To(user.Email, user.Username)
                .Subject(subject)
                .Body(GetEmailBody(user), isHtml: true)
                .SendAsync();

            logger.LogInformation("[{Source}]: Verification email sent successfully to {Email}.", Source, user.Email);
        }
        catch (Exception ex)
        {
            logger.LogError("[{Source}]: Failed to send verification email to {Email}. Exception message - {Exception}",
                Source, user.Email, ex.Message);
        }
    }

    private string GetEmailBody(User user)
    {
        logger.LogInformation("[{Source}]: Building verification email body...", Source);

        var encryptedEmail = HttpUtility.UrlEncode(emailCryptoService.Encrypt(user.Email));
        var verificationUrl = $"{frontendUrl}/auth/verify?token={encryptedEmail}";

        return $"""

                <html lang="en">
                  <body style="font-family: 'Montserrat', Arial, sans-serif">
                    <p
                      style="
                        font-weight: bold;
                        font-size: 30px;
                        color: #1e1f29;
                        text-transform: uppercase;
                      "
                    >
                      digite<span style="color: crimson">x</span>
                    </p>

                    <p style="font-weight: bold; font-size: 20px; color: #15161d">
                      Confirm your account
                    </p>

                    <hr style="border: none; border-top: 1px solid #ddd; margin: 20px 0" />

                    <p style="color: #15161d; font-size: 16px; margin: 20px 0">
                      Hello, {user.Username}!<br />Thank you for signing up. Please verify your
                      account by clicking the button below:
                    </p>

                    <a
                      href="{verificationUrl}"
                      style="
                        display: inline-block;
                        padding: 12px 24px;
                        background-color: #e02b4a;
                        color: #fff;
                        text-decoration: none;
                        border-radius: 5px;
                        font-family: 'Montserrat', Arial, sans-serif;
                      "
                    >
                      Verify My Account
                    </a>

                    <hr style="border: none; border-top: 1px solid #ddd; margin: 20px 0" />

                    <p style="font-size: 14px; font-weight: 600; color: #1e1f29">
                      This email was sent by DIGITE<span style="color: #e02b4a">X</span>. If you
                      did not sign up, please ignore this message.
                    </p>
                  </body>
                </html>

                """;
    }
}