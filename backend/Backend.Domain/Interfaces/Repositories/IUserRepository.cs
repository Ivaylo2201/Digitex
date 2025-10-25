using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface IUserRepository : ICreatable<User>, IReadable<User, int>
{
    Task<bool> IsUsernameAvailableAsync(string username, CancellationToken cancellationToken = default);
    Task<User?> GetOneByCredentialsAsync(string username, string password, CancellationToken cancellationToken = default);
}