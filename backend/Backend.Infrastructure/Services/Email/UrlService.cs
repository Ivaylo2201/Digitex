using System.Web;
using Backend.Application.Interfaces.Email;
using Backend.Domain.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Backend.Infrastructure.Services.Email;

public class UrlService(IConfiguration configuration) : IUrlService
{
    private readonly string _frontendUrl = configuration["Urls:Frontend"] ?? throw new ImproperlyConfiguredException("Frontend url is null or empty.");

    public string GetPasswordResetUrl(string rawToken) => $"{_frontendUrl}/account/complete-password-reset?token={HttpUtility.UrlEncode(rawToken)}";
    public string GetAccountVerificationUrl(string rawToken) => $"{_frontendUrl}/account/verify?token={HttpUtility.UrlEncode(rawToken)}";
}