using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
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

    public async Task RemoveFromCartAsync(int userId, int itemId, CancellationToken stoppingToken)
    {
        var item = await context.Items
            .Include(item => item.Cart)
            .ThenInclude(cart => cart.User)
            .FirstOrDefaultAsync(item => item.Id == itemId && item.Cart.User.Id == userId, stoppingToken);

        if (item is null)
            return;
        
        context.Items.Remove(item);
        await context.SaveChangesAsync(stoppingToken);
    }

    public async Task UpdateItemQuantityAsync(int userId, int itemId, int quantity, CancellationToken stoppingToken)
    {
        var item = await context.Items
            .Include(item => item.Cart)
            .ThenInclude(cart => cart.User)
            .FirstOrDefaultAsync(item => item.Id == itemId && item.Cart.User.Id == userId, stoppingToken);

        if (item is null)
            return;

        item.Quantity = quantity;
        context.Items.Update(item);
        await context.SaveChangesAsync(stoppingToken);
    }

    public async Task ClearCartAsync(int userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}