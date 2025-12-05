namespace Backend.Application.Interfaces.Services;

public interface ITokenService
{
    string? GenerateToken(int size = 32);
    bool TryHashToken(string raw, out string hashed);
}