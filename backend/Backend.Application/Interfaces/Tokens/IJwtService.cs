using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Tokens;

public interface IJwtService
{
    string GenerateToken(User user);
}