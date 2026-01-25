using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories.Generics;

namespace Backend.Domain.Interfaces;

public interface IUserTokenRepository : ICreatable<UserToken>, IDeletable<int>
{
    Task<UserToken?> GetActiveTokenByHashWithUserAsync(string hash, CancellationToken stoppingToken = default);
}