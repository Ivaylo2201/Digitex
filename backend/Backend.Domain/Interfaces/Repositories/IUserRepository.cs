using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface IUserRepository : ICreatable<User>, ISingleReadable<User, int>
{
    Task<bool> IsUsernameAvailableAsync(string username, CancellationToken ct = default);
    Task<User?> GetOneByCredentialsAsync(string username, string password, CancellationToken ct = default);
}