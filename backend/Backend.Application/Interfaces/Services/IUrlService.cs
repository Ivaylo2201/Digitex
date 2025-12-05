namespace Backend.Application.Interfaces.Services;

public interface IUrlService
{
    public string PasswordResetUrl(string rawToken);
    public string AccountVerificationUrl(string rawToken);
}