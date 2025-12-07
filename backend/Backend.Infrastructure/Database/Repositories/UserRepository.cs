using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class UserRepository(DatabaseContext context) : IUserRepository
{
    public async Task<User> CreateAsync(User user, CancellationToken stoppingToken = default)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        
        var entity = (await context.Users.AddAsync(user, stoppingToken)).Entity;
        await context.SaveChangesAsync(stoppingToken);
        return entity;
    }

    public async Task<User?> GetOneByEmailAsync(string email, CancellationToken stoppingToken = default)
        => await VerifiedUsers.FirstOrDefaultAsync(user => user.Email == email, stoppingToken);

    public async Task<User?> GetOneByCredentialsAsync(string email, string password, CancellationToken stoppingToken = default)
    {
        var user = await VerifiedUsers.FirstOrDefaultAsync(user => user.Email == email, stoppingToken);
        return BCrypt.Net.BCrypt.Verify(password, user?.Password) ? user : null;
    }

    public async Task<User?> VerifyUserAsync(int id, CancellationToken stoppingToken = default)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Id == id && !user.IsVerified, stoppingToken);
        
        user?.IsVerified = true;
        await context.SaveChangesAsync(stoppingToken);
        return user;
    }

    public async Task ResetPasswordAsync(int id, string newPassword, CancellationToken stoppingToken = default)
    {
        var user = await VerifiedUsers.FirstOrDefaultAsync(user => user.Id == id, stoppingToken);
        user?.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        await context.SaveChangesAsync(stoppingToken);
    }

    public async Task<User?> GetOneAsync(int id, CancellationToken stoppingToken = default)
        => await VerifiedUsers.FirstOrDefaultAsync(user => user.Id == id, stoppingToken);
    
    private IQueryable<User> VerifiedUsers 
        => context.Users.Where(user => user.IsVerified);
}