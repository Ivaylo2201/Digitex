namespace Backend.Application.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(int size = 32);
    string HashToken(string raw);
}