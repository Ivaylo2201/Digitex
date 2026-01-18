using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces;

public interface IUserTokenRepository : ICreatable<UserToken>, IDeletable<int>
{
    Task<UserToken?> GetActiveTokenByHashWithUserAsync(string hash, CancellationToken stoppingToken = default);
}