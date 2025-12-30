using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class CartRepository(DatabaseContext context) : ICartRepository
{
    public async Task AddToCartAsync(Item item, CancellationToken stoppingToken)
    {
        await context.Items.AddAsync(item, stoppingToken);
        await context.SaveChangesAsync(stoppingToken);
    }

    public async Task<Cart?> GetCartAsync(int userId, CancellationToken stoppingToken)
        => await context.Carts
            .Include(cart => cart.Items)
            .ThenInclude(item => item.Product)
            .ThenInclude(product => product.Brand)
            .FirstOrDefaultAsync(cart => cart.UserId == userId, stoppingToken);
}