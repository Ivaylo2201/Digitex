using System.Security.Cryptography;
using System.Text;
using Backend.Application.Interfaces.Services;

namespace Backend.Infrastructure.Services.Common;

public class TokenService : ITokenService
{
    public string GenerateToken(int size = 32)
    {
        var bytes = new byte[size];
        RandomNumberGenerator.Fill(bytes);
        return Convert.ToBase64String(bytes);
    }

    public string HashToken(string token)
    {
        var bytes = Encoding.UTF8.GetBytes(token);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
}