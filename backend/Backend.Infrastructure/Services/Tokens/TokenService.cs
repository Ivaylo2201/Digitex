using System.Security.Cryptography;
using System.Text;
using Backend.Application.Interfaces.Services;

namespace Backend.Infrastructure.Services.Tokens;

public class TokenService : ITokenService
{
    public string GenerateToken(int size = 32)
    {
        var bytes = new byte[size];
        RandomNumberGenerator.Fill(bytes);
        var token = Convert.ToBase64String(bytes);
        Console.WriteLine($"Generated: {token}");
        return token;
    }

    public string HashToken(string rawToken)
    {
        var hashed = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(rawToken)));
        Console.WriteLine($"Hashed: {hashed}");
        return hashed;
    }
}