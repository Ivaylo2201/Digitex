namespace Backend.Application.Interfaces.Services;

public interface IUrlService
{
    public string ResetPasswordUrl(string rawToken);
    public string AccountVerificationUrl(string rawToken);
}