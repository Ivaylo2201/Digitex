using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class CartRepository(ILogger<CartRepository> logger, DatabaseContext context) : ICartRepository
{
    private const string Source = nameof(CartRepository);
    
    public async Task<Cart?> GetCartForUserAsync(int userId, CancellationToken stoppingToken = default)
    {
        var user = await context.Users
            .Include(user => user.Cart)
            .FirstOrDefaultAsync(user => user.Id == userId, stoppingToken);

        if (user is null)
        {
            logger.LogInformation("[{Source}]: User with Id={UserId} not found, so no related cart exists.", Source, userId);
            return null;
        }
        
        return user.Cart;
    }
}