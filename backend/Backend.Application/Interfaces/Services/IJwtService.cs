using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Services;

public interface IJwtService
{
    string GenerateJwt(User user);
}