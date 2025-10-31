using System.Diagnostics;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

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

    public async Task<bool> VerifyUserAsync(string email, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        var user = await context.Users.FirstOrDefaultAsync(user => !user.IsVerified && user.Email == email, stoppingToken);
        
        if (user is null)
        {
            logger.LogError("[{Source}]: User entity with Email={Email} not found.", Source, email);
            return false;
        }

        if (user.IsVerified)
        {
            logger.LogError("[{Source}]: User entity with Email={Email} already verified.", Source, email);
            return false;       
        }
        
        user.IsVerified = true;
        await context.SaveChangesAsync(stoppingToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: User entity with Email={Email} verified in {Duration}ms.", Source, email, stopwatch.ElapsedMilliseconds);
        return true;
    }

    public async Task<User?> GetOneAsync(int id, CancellationToken stoppingToken = default)
        => await context.Users.FirstOrDefaultAsync(user => user.IsVerified && user.Id == id, stoppingToken);
}