namespace Backend.Application.Interfaces.Tokens;

public interface ITokenService
{
    string GenerateToken(int size = 32);
    string HashToken(string raw);
}