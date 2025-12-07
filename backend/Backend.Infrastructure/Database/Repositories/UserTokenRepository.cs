using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class UserTokenRepository(DatabaseContext context) : IUserTokenRepository
{
    public async Task<UserToken> CreateAsync(UserToken userToken, CancellationToken stoppingToken = default)
    {
        var token = (await context.UserTokens.AddAsync(userToken, stoppingToken)).Entity;
        await context.SaveChangesAsync(stoppingToken);
        return token;
    }

    public async Task<UserToken?> GetActiveTokenByHashWithUserAsync(string hashedToken, CancellationToken stoppingToken = default)
    {
        var userToken = await context.UserTokens
            .AsNoTracking()
            .Include(userToken => userToken.User)
            .FirstOrDefaultAsync(userToken => userToken.Hash == hashedToken, stoppingToken);

        if (userToken is not null && userToken.IsExpired)
            return null;
        
        return userToken;
    }

    public async Task DeleteAsync(int id, CancellationToken stoppingToken = default)
        => await context.UserTokens.Where(x => x.Id == id).ExecuteDeleteAsync(stoppingToken);
}