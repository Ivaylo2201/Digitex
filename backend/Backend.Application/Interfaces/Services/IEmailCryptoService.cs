namespace Backend.Application.Interfaces.Services;

public interface IEmailCryptoService
{
    string Encrypt(string email);
    string Decrypt(string encryptedEmail);
}