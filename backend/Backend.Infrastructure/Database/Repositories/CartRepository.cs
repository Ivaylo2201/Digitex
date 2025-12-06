using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories;

public class CartRepository(ILogger<CartRepository> logger, DatabaseContext context) : ICartRepository
{
    private const string Source = nameof(CartRepository);
    
    public async Task<Cart?> GetCartForUserAsync(int? userId, CancellationToken stoppingToken = default)
    {
        var user = await context.Users
            .Include(user => user.Cart)
            .FirstOrDefaultAsync(user => user.Id == userId, stoppingToken);

        if (user is null)
        {
            logger.LogError("[{Source}]: User with Id={UserId} not found, so no related cart exists.", Source, userId);
            return null;
        }
        
        return user.Cart;
    }

    public async Task<double> GetCartTotalAsync(int userId, CancellationToken stoppingToken = default)
    {
        return await context.Users
            .Where(user => user.Id == userId)
            .Include(user => user.Cart)
            .ThenInclude(cart => cart.Items)
            .SelectMany(user => user.Cart.Items)
            .SumAsync(item => item.Price, stoppingToken);
    }
}