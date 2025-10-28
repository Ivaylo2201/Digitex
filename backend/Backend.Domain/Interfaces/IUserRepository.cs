using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces;

public interface IUserRepository : ICreatable<User>, ISingleReadable<User, int>
{
    Task<bool> IsUsernameAvailableAsync(string username, CancellationToken stoppingToken = default);
    Task<User?> GetOneByCredentialsAsync(string username, string password, CancellationToken stoppingToken = default);
}