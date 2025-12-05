using System.Security.Cryptography;
using System.Text;
using Backend.Application.Interfaces.Services;
using Backend.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Common;

public class TokenService(ILogger<TokenService> logger) : ITokenService
{
    private const string Source = nameof(TokenService);
    
    public string? GenerateToken(int size = 32)
    {
        try
        {
            var bytes = new byte[size];
            RandomNumberGenerator.Fill(bytes);
            return Convert.ToBase64String(bytes);
        }
        catch (Exception ex)
        {
            logger.LogException(Source, ex, "generating a token");
            return null;
        }
    }

    public bool TryHashToken(string raw, out string hashed)
    {
        try
        {
            var bytes = Encoding.UTF8.GetBytes(raw);
            var hash = SHA256.HashData(bytes);
            hashed = Convert.ToBase64String(hash);
            return true;
        }
        catch (Exception ex)
        {
            logger.LogException(Source, ex, "hashing a token");
            hashed = string.Empty;
            return false;
        }
    }
}