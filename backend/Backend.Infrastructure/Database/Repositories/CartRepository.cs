using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class CartRepository(DatabaseContext context) : ICartRepository
{
    public async Task<double> GetCartTotalAsync(int userId, CancellationToken stoppingToken = default)
    {
        return await context.Users
            .Where(user => user.Id == userId)
            .Include(user => user.Cart)
            .ThenInclude(cart => cart.Items)
            .SelectMany(user => user.Cart.Items)
            .SumAsync(item => item.Price, stoppingToken);
    }

    public async Task AddToCartAsync(Item item, CancellationToken stoppingToken)
    {
        await context.Items.AddAsync(item, stoppingToken);
        await context.SaveChangesAsync(stoppingToken);
    }
}