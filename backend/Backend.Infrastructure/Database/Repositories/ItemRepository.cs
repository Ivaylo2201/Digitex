using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class ItemRepository(DatabaseContext context) : IItemRepository
{
    public async Task<Item> CreateAsync(Item item, CancellationToken cancellationToken = default)
    {
        var entity = (await context.Items.AddAsync(item, cancellationToken)).Entity;
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        => await context.Items.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);

    public async Task<Item?> GetOneByIdWithCartAsync(int itemId, CancellationToken cancellationToken)
        => await context.Items
            .AsNoTracking()
            .Include(item => item.Cart)
            .ThenInclude(cart => cart.User)
            .FirstOrDefaultAsync(item => item.Id == itemId, cancellationToken);

    public async Task<Item?> GetOneByIdWithProductAsync(int itemId, CancellationToken cancellationToken)
        => await context.Items
            .AsNoTracking()
            .Include(item => item.Product)
            .FirstOrDefaultAsync(item => item.Id == itemId, cancellationToken);

    public async Task UpdateQuantityAsync(int itemId, int newQuantity, CancellationToken cancellationToken)
    {
        var item = await context.Items.FirstOrDefaultAsync(item => item.Id == itemId, cancellationToken);
        item?.Quantity = newQuantity;
        await context.SaveChangesAsync(cancellationToken);
    }
}