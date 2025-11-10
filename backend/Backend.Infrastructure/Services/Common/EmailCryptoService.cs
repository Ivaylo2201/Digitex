using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Backend.Application.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Common;

public class EmailCryptoService(ILogger<EmailCryptoService> logger, byte[] key, byte[] iv) : IEmailCryptoService
{
    private const string Source = nameof(EmailCryptoService);

    public string Encrypt(string email)
    {
        logger.LogInformation("[{Source}]: Encrypting email={Email}", Source, email);
        var stopwatch = Stopwatch.StartNew();
        
        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        var encryptor = aes.CreateEncryptor();
        var bytes = Encoding.UTF8.GetBytes(email);

        using var memoryStream = new MemoryStream();
        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        {
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
        }

        var encryptedEmail = Convert.ToBase64String(memoryStream.ToArray()); logger.LogInformation("[{Source}]: Email encryption done in {Duration}ms", Source, stopwatch.ElapsedMilliseconds);
        return encryptedEmail;
    }

    public string Decrypt(string encryptedEmail)
    {
        logger.LogInformation("[{Source}]: Decrypting email...", Source);
        var stopwatch = Stopwatch.StartNew();

        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        var decryptor = aes.CreateDecryptor();
        using var memoryStream = new MemoryStream(Convert.FromBase64String(encryptedEmail.Trim()));
        using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        using var reader = new StreamReader(cryptoStream, Encoding.UTF8);
        
        var decryptedEmail = reader.ReadToEnd();
        logger.LogInformation("[{Source}]: Email decryption resolved to {DecryptedEmail} in {Duration}ms", Source, decryptedEmail, stopwatch.ElapsedMilliseconds);

        return decryptedEmail;
    }
}