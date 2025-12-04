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

        await context.UserTokens.AddAsync(userToken, stoppingToken);
        await context.SaveChangesAsync(stoppingToken);

        stopwatch.Stop();
            
        var tokenType = userToken.UserTokenType.ToString();
        var remainingTimeInMinutes = (userToken.ExpiresAt - userToken.CreatedAt).Minutes;

        logger.LogInformation(
            "[{Source}]: {TokenType} UserToken entity with UserId={UserId} created in {Duration}ms.", Source,
            tokenType, userToken.UserId, stopwatch.ElapsedMilliseconds);
        logger.LogInformation(
            "[{Source}]: Token will be active for {RemainingTimeInMinutes} minutes until {Timestamp}.", Source,
            remainingTimeInMinutes, userToken.ExpiresAt);

        return userToken;
    }

    public async Task<UserToken?> GetByHashedTokenWithUserAsync(string hashedToken, CancellationToken stoppingToken = default)
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

        if (DateTime.UtcNow > userToken.ExpiresAt)
        {
            logger.LogWarning("[{Source}]: UserToken with with Hash={hashedToken} found in {Duration}ms, but it is expired.", Source, hashedToken, stopwatch.ElapsedMilliseconds);
            return null;
        }
        
        logger.LogInformation("[{Source}]: UserToken entity with with Hash={hashedToken} found in {Duration}ms", Source, hashedToken, stopwatch.ElapsedMilliseconds);
        return userToken;
    }
}