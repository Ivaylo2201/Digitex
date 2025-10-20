using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}