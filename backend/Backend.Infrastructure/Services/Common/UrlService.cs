using Backend.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace Backend.Infrastructure.Services.Common;

public class UrlService(IConfiguration configuration) : IUrlService
{
    private readonly string _frontendUrl = configuration["Urls:Frontend"]!;

    public string PasswordResetUrl(string rawToken) => $"{_frontendUrl}/account/complete-password-reset?token={rawToken}";
    public string AccountVerificationUrl(string rawToken) => $"{_frontendUrl}/account/verify?token={rawToken}";
}