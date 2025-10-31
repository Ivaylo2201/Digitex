using System.Security.Cryptography;
using System.Text;
using Backend.Application.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Common;

public class EmailCryptoService : IEmailCryptoService
{
    private const string Source = nameof(EmailCryptoService);
    private readonly byte[] _key;
    private readonly byte[] _iv;
    private readonly ILogger<EmailCryptoService> _logger;

    public EmailCryptoService(ILogger<EmailCryptoService> logger)
    {
        using var aes = Aes.Create();
        _key = aes.Key;
        _iv = aes.IV;
        _logger = logger;
    }

    public string Encrypt(string email)
    {
        _logger.LogInformation("[{Source}]: Encrypting email...", Source);
        
        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;

        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        var bytes = Encoding.UTF8.GetBytes(email);

        using var memoryStream = new MemoryStream();
        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        {
            cryptoStream.Write(bytes, 0, bytes.Length);
        }

        return Convert.ToBase64String(memoryStream.ToArray());
    }

    public string Decrypt(string encrypted)
    {
        _logger.LogInformation("[{Source}]: Decrypting email...", Source);
        
        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        var bytes = Convert.FromBase64String(encrypted);

        using var memoryStream = new MemoryStream(bytes);
        using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        using var reader = new StreamReader(cryptoStream, Encoding.UTF8);
        return reader.ReadToEnd();
    }
}