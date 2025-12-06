using System.Diagnostics;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories;

public class UserRepository(ILogger<UserRepository> logger, DatabaseContext context) : IUserRepository
{
    private const string Source = nameof(UserRepository);
    
    public async Task<User> CreateAsync(User user, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Hashing password...", Source);
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        
        await context.Users.AddAsync(user, stoppingToken);
        await context.SaveChangesAsync(stoppingToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: User entity with Username={Username} created in {Duration}ms.", Source, user.Username, stopwatch.ElapsedMilliseconds);
        return user;
    }

    public async Task<User?> GetOneByEmailAsync(string email, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Getting User entity with Email={Email}", Source, email);
        
        var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Email == email, stoppingToken);
        
        if (user is null)
        {
            logger.LogError("[{Source}]: User entity with Email={Email} not found.", Source, email);
            return null;
        }
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: User entity with Email={Email} retrieved in {Duration}ms.", Source, email, stopwatch.ElapsedMilliseconds);
        return user;
    }

    public async Task<User?> GetOneByCredentialsAsync(string email, string password, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Getting User entity with Email={Email}", Source, email);
        
        var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.IsVerified && user.Email == email, stoppingToken);
        
        if (user is null)
        {
            logger.LogError("[{Source}]: User entity with Email={Email} not found.", Source, email);
            return null;
        }

        if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            logger.LogError("[{Source}]: Incorrect password provided for User with Email={Email}.", Source, email);
            return null;
        }
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: User entity with Email={Email} retrieved in {Duration}ms.", Source, email, stopwatch.ElapsedMilliseconds);
        return user;
    }

    public async Task<User?> GetOneWithItemsAndProductsAsync(int userId, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        logger.LogInformation("[{Source}]: Getting User entity with Id={Id}.", Source, userId);

        var user = await context.Users
            .AsNoTracking()
            .Include(user => user.Cart)
            .ThenInclude(cart => cart.Items)
            .ThenInclude(item => item.Product)
            .FirstOrDefaultAsync(user => user.IsVerified && user.Id == userId, stoppingToken);
        
        if (user is null)
        {
            logger.LogError("[{Source}]: User entity with with Id={Id} not found.", Source, userId);
            return null;
        }
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: User entity with Id={Id} retrieved in {Duration}ms.", Source, userId, stopwatch.ElapsedMilliseconds);
        return user;
    }

    public async Task<User?> VerifyUserAsync(int id, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        var user = await context.Users.FirstOrDefaultAsync(user => user.Id == id, stoppingToken);
        
        if (user is null)
        {
            logger.LogError("[{Source}]: User entity with Id={Id} not found.", Source, id);
            return null;
        }

        if (user.IsVerified)
        {
            logger.LogError("[{Source}]: User entity with Id={Id} already verified.", Source, id);
            return null;
        }
        
        user.IsVerified = true;
        await context.SaveChangesAsync(stoppingToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: User entity with Id={Id} verified in {Duration}ms.", Source, id, stopwatch.ElapsedMilliseconds);
        return user;
    }

    public async Task ResetPasswordAsync(int id, string newPassword, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        var user = await context.Users.FirstOrDefaultAsync(user => user.Id == id, stoppingToken);
        
        if (user is null)
        {
            logger.LogError("[{Source}]: User entity with Id={Id} not found.", Source, id);
            return;
        }
        
        user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        await context.SaveChangesAsync(stoppingToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: User entity with Id={Id} password reset in {Duration}ms.", Source, id, stopwatch.ElapsedMilliseconds);
    }

    public async Task<User?> GetOneAsync(int id, CancellationToken stoppingToken = default)
        => await context.Users.FirstOrDefaultAsync(user => user.IsVerified && user.Id == id, stoppingToken);
}