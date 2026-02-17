using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface IUserRepository : ICreatable<User>, ISingleReadable<User, int>
{
    Task<User?> GetOneByEmailAsync(string email, CancellationToken stoppingToken = default);
    Task<User?> GetOneByCredentialsAsync(string email, string password, CancellationToken stoppingToken = default);
    Task<User?> VerifyUserAsync(int id, CancellationToken stoppingToken = default);
    Task ResetPasswordAsync(int id, string newPassword, CancellationToken stoppingToken = default);
    Task<User?> GetOneByIdWithCartAsync(int id, CancellationToken stoppingToken = default);
    Task<User?> GetOneWithFavoritesAsync(int id, CancellationToken stoppingToken = default);
    Task SaveChangesAsync(CancellationToken stoppingToken = default);
}