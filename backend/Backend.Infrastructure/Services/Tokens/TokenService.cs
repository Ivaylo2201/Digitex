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
        return Convert.ToBase64String(bytes);
    }

    public string HashToken(string rawToken) => Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(rawToken)));
}