using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using FluentEmail.Core;

namespace Backend.Infrastructure.Services.Common;

public class EmailSendingService(IFluentEmail fluentEmail, IEmailCryptoService emailCryptoService) : IEmailSendingService
{
    public async Task SendWelcomeEmailAsync(User user, CancellationToken stoppingToken = default)
    {
        // await fluentEmail
        //     .To(user.Email, user.Username)
        //     .Subject("Welcome to MyApp!")
        //     .Body(GetEmailBody(user))
        //     .SendAsync();
    }

    private static string GetEmailBody(User user)
    {
        // The body shoudl contain http://localhost:<frontend>/verify?token=<encyrpted mail>
        throw new NotImplementedException();
    }
}