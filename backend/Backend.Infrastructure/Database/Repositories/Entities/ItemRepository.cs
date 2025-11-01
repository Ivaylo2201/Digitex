using System.Diagnostics;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class ItemRepository(ILogger<ItemRepository> logger, DatabaseContext context) : IItemRepository
{
    private const string Source = nameof(ItemRepository);
    
    public async Task<Item> CreateAsync(Item item, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        var entry = await context.Items.AddAsync(item, stoppingToken);
        await context.SaveChangesAsync(stoppingToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: Item entity with ProductId={ProductId} and Quantity={Quantity} created in {Duration}ms.", Source, item.ProductId, item.Quantity, stopwatch.ElapsedMilliseconds);
        return entry.Entity;
    }

    public async Task<List<Item>> GetItemsInUserCartAsync(int userId, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        var items = await context.Items
            .Include(item => item.Cart)
            .Where(item => item.Cart.UserId == userId)
            .ToListAsync(stoppingToken);
        
        stopwatch.Stop();
        logger.LogError("[{Source}]: Items retrieved in {Duration}ms", Source, stopwatch.ElapsedMilliseconds);
        
        return items;       
    }

    public async Task<bool> IsItemOwnedByUserAsync(int itemId, int userId, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();

        var item = await context.Items
            .Include(item => item.Cart)
            .ThenInclude(cart => cart.User)
            .FirstOrDefaultAsync(item => item.Id == itemId, stoppingToken);

        if (item is null || item.Cart.User.Id != userId)
        {
            logger.LogError("[{Source}]: Item with Id={ItemId} not found or user does not own the item.", Source, itemId);
            return false;
        }
        
        stopwatch.Stop();
        logger.LogError("[{Source}]: Item with Id={ItemId} ownership check done in {Duration}ms", Source, itemId, stopwatch.ElapsedMilliseconds);
        return true;
    }

    public async Task DeleteAsync(int id, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();

        var item = await context.Items.FirstOrDefaultAsync(item => item.Id == id, stoppingToken);

        if (item is null)
            return;
        
        context.Items.Remove(item);
        await context.SaveChangesAsync(stoppingToken);
        
        stopwatch.Stop();
        logger.LogError("[{Source}]: Item with Id={ItemId} deleted in {Duration}ms", Source, id, stopwatch.ElapsedMilliseconds);
    }
}