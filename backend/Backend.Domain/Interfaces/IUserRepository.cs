using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces;

public interface IUserRepository : ICreatable<User>, ISingleReadable<User, int>
{
    Task<User?> GetOneByCredentialsAsync(string email, string password, CancellationToken stoppingToken = default);
    Task<User?> VerifyUserAsync(int id, CancellationToken stoppingToken = default);
}