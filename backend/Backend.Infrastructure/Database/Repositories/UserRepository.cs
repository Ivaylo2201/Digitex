using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class UserRepository(DatabaseContext context) : IUserRepository
{
    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        
        var entity = (await context.Users.AddAsync(user, cancellationToken)).Entity;
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<User?> GetOneByEmailAsync(string email, CancellationToken cancellationToken = default)
        => await VerifiedUsers.FirstOrDefaultAsync(user => user.Email == email, cancellationToken);

    public async Task<User?> GetOneByCredentialsAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Email == email, cancellationToken);

        if (user is null)
            return null;
        
        return BCrypt.Net.BCrypt.Verify(password, user.Password) ? user : null;
    }

    public async Task<User?> VerifyUserAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Id == id && !user.IsVerified, cancellationToken);
        
        user?.IsVerified = true;
        await context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task ResetPasswordAsync(int id, string newPassword, CancellationToken cancellationToken = default)
    {
        var user = await VerifiedUsers.FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        user?.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<User?> GetOneByIdWithCartAsync(int id, CancellationToken cancellationToken = default)
        => await VerifiedUsers
            .Include(user => user.Cart)
            .ThenInclude(cart => cart.Items)
            .ThenInclude(item => item.Product)
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);

    public async Task<User?> GetOneWithFavoritesAsync(int id, CancellationToken cancellationToken = default)
        => await VerifiedUsers.Include(user => user.Wishlist).FirstOrDefaultAsync(user => user.Id == id, cancellationToken);

    public async Task SaveChangesAsync(CancellationToken stoppingToken = default)
    {
        await context.SaveChangesAsync(stoppingToken);
    }

    public async Task<User?> GetOneAsync(int id, CancellationToken cancellationToken = default)
        => await VerifiedUsers.FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    
    private IQueryable<User> VerifiedUsers 
        => context.Users.Where(user => user.IsVerified);
}