using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces;

public interface IUserRepository : ICreatable<User>, ISingleReadable<User, int>
{
    Task<User?> GetOneByCredentialsAsync(string email, string password, CancellationToken stoppingToken = default);
    Task<User?> GetOneWithItemsAndProductsAsync(int userId, CancellationToken stoppingToken = default);
    Task<bool> VerifyUserAsync(string email, CancellationToken stoppingToken = default);
}