using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces;

public interface IUserTokenRepository : ICreatable<UserToken>
{
    Task<UserToken?> GetByHashedTokenWithUserAsync(string hashedToken, CancellationToken stoppingToken = default);
}