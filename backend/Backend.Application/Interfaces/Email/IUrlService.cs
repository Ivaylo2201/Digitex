namespace Backend.Application.Interfaces.Email;

public interface IUrlService
{
    public string GetPasswordResetUrl(string rawToken);
    public string GetAccountVerificationUrl(string rawToken);
}