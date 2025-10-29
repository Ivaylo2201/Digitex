using System.Security.Cryptography;
using System.Text;
using Backend.Application.Interfaces.Services;

namespace Backend.Infrastructure.Services.Common;

public class EmailCryptoService : IEmailCryptoService
{
    private readonly byte[] _key;
    private readonly byte[] _iv;

    public EmailCryptoService()
    {
        using var aes = Aes.Create();
        _key = aes.Key;
        _iv = aes.IV;
    }

    public string Encrypt(string email)
    {
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