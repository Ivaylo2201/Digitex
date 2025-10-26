using System.Diagnostics;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Infrastructure.Database.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class UserRepository(ILogger<UserRepository> logger, DatabaseContext context) : IUserRepository
{
    private readonly SingleReadableRepository<User, int> _singleRepository = new(logger, context);
    private const string Source = nameof(UserRepository);
    
    public async Task<User> CreateAsync(User user, CancellationToken ct = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Hashing password...", Source);
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        
        await context.Users.AddAsync(user, ct);
        await context.SaveChangesAsync(ct);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: User entity with Username={Username} created in {Duration}ms.", Source, user.Username, stopwatch.ElapsedMilliseconds);
        return user;
    }
    
    public async Task<bool> IsUsernameAvailableAsync(string username, CancellationToken ct = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Checking whether Username={Username} is available...", Source, username);
        
        var entity = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == username, ct);

        if (entity is null)
        {
            logger.LogInformation("[{Source}]: Username={Username} is available.", Source, username);
            LogUsernameCheckDuration(stopwatch, username);
            return true;
        }
        
        logger.LogInformation("[{Source}]: Username={Username} is not available.", Source, username);
        LogUsernameCheckDuration(stopwatch, username);
        return false;
    }

    public async Task<User?> GetOneByCredentialsAsync(string username, string password, CancellationToken ct = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Getting User entity with Username={Username}", Source, username);
        
        var entity = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Username == username, ct);
        
        if (entity is null)
        {
            logger.LogError("[{Source}]: User entity with Username={Username} not found.", Source, username);
            return null;
        }

        if (!BCrypt.Net.BCrypt.Verify(password, entity.Password))
        {
            logger.LogError("[{Source}]: Incorrect password provided for User with Username={Username}.", Source, username);
            return null;
        }
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: User entity with Username={Username} retrieved in {Duration}ms.", Source, username, stopwatch.ElapsedMilliseconds);
        return entity;
    }
    
    public async Task<User?> GetOneAsync(int id, IncludeQuery<User>? include = null, CancellationToken ct = default)
        => await _singleRepository.GetOneAsync(id, include, ct);

    private void LogUsernameCheckDuration(Stopwatch stopwatch, string username)
    {
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: Username={Username} availability check done in {Duration}ms.", Source, username, stopwatch.ElapsedMilliseconds);
    }
}