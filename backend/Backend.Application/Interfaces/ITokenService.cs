using Backend.Domain.Entities;

namespace Backend.Application.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}