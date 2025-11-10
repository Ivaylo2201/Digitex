using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Backend.Application.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Common;

public class EmailCryptoService(
    ILogger<EmailCryptoService> logger,
    IWebHostEnvironment environment,
    byte[] key,
    byte[] iv) : IEmailCryptoService
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

        var token = Convert.ToBase64String(memoryStream.ToArray());

        if (environment.IsDevelopment())
        {
            logger.LogInformation("[{Source}]: Email encrypted to {Token} in {Duration}ms", Source, token, stopwatch.ElapsedMilliseconds);
        }

        return token;
    }

    public string Decrypt(string token)
    {
        logger.LogInformation("[{Source}]: Decrypting email...", Source);
        var stopwatch = Stopwatch.StartNew();

        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        var decryptor = aes.CreateDecryptor();
        using var memoryStream = new MemoryStream(Convert.FromBase64String(token.Trim()));
        using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        using var reader = new StreamReader(cryptoStream, Encoding.UTF8);
        
        var email = reader.ReadToEnd();
        
        if (environment.IsDevelopment())
        {
            logger.LogInformation("[{Source}]: Token decrypted to {Email} in {Duration}ms", Source, email, stopwatch.ElapsedMilliseconds);
        }

        return email;
    }
}