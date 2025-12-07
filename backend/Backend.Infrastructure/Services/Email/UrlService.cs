using Backend.Application.Interfaces.Services;
using Backend.Domain.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Backend.Infrastructure.Services.Email;

public class UrlService(IConfiguration configuration) : IUrlService
{
    private readonly string _frontendUrl = configuration["Urls:Frontend"] ?? throw new ImproperlyConfiguredException("Frontend url is null or empty.");

    public string PasswordResetUrl(string rawToken) => $"{_frontendUrl}/account/complete-password-reset?token={rawToken}";
    public string AccountVerificationUrl(string rawToken) => $"{_frontendUrl}/account/verify?token={rawToken}";
}