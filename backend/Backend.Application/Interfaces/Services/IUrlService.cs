namespace Backend.Application.Interfaces.Services;

public interface IUrlService
{
    public string GetPasswordResetUrl(string rawToken);
    public string GetAccountVerificationUrl(string rawToken);
}