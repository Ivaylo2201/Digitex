using System.Diagnostics;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class UserTokenRepository(ILogger<UserTokenRepository> logger, DatabaseContext context) : IUserTokenRepository
{
    private const string Source = nameof(UserRepository);
    
    public async Task<UserToken> CreateAsync(UserToken userToken, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();

        var token = (await context.UserTokens.AddAsync(userToken, stoppingToken)).Entity;
        await context.SaveChangesAsync(stoppingToken);

        stopwatch.Stop();

        logger.LogInformation(
            "[{Source}]: UserToken entity with UserId={UserId} and type={TokenType} created in {Duration}ms.", Source,
            userToken.UserId,  userToken.UserTokenType.ToString(), stopwatch.ElapsedMilliseconds);
        logger.LogInformation(
            "[{Source}]: Token with Id={TokenId} will be active for {RemainingTimeInMinutes} minutes until {Timestamp}.", Source, token.Id,
            token.RemainingTimeOfActivityInMinutes, userToken.ExpiresAt);

        return userToken;
    }

    public async Task<UserToken?> GetActiveTokenByHashWithUserAsync(string hashedToken, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Getting UserToken entity with Hash={hashedToken}...", Source, hashedToken);
        
        var userToken = await context.UserTokens
            .AsNoTracking()
            .Include(userToken => userToken.User)
            .FirstOrDefaultAsync(userToken => userToken.Hash == hashedToken, stoppingToken);
        
        stopwatch.Stop();
        
        if (userToken is null)
        {
            logger.LogWarning("[{Source}]: UserToken with with Hash={hashedToken} not found in {Duration}ms", Source, hashedToken, stopwatch.ElapsedMilliseconds);
            return null;
        }

        if (userToken.IsExpired)
        {
            logger.LogWarning("[{Source}]: UserToken with with Hash={hashedToken} found in {Duration}ms, but it is expired.", Source, hashedToken, stopwatch.ElapsedMilliseconds);
            return null;
        }
        
        logger.LogInformation("[{Source}]: UserToken entity with with Hash={hashedToken} found in {Duration}ms", Source, hashedToken, stopwatch.ElapsedMilliseconds);
        return userToken;
    }

    public async Task DeleteAsync(int id, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        var affected = await context.UserTokens
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync(stoppingToken);
        
        stopwatch.Stop();

        if (affected is 0)
            logger.LogWarning("[{Source}]: UserToken with with Id={Id} not found in {Duration}ms", Source, id, stopwatch.ElapsedMilliseconds);
    }
}