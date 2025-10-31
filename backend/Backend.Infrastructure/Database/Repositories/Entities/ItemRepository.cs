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
        
        await context.Items.AddAsync(item, stoppingToken);
        await context.SaveChangesAsync(stoppingToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: Item entity with ProductId={ProductId} and Quantity={Quantity} created in {Duration}ms.", Source, item.ProductId, item.Quantity, stopwatch.ElapsedMilliseconds);
        return item;
    }

    public async Task<Item?> GetOneAsync(int id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Item>?> ListItemsInCartAsync(int userId, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        var user = await context.Users
            .Include(user => user.Cart)
            .FirstOrDefaultAsync(user => user.Id == userId, stoppingToken);

        if (user is null)
        {
            logger.LogInformation("[{Source}]: User with Id={UserId} not found, so no related cart exists.", Source, userId);
            return null;
        }

        var items = await context.Items
            .Where(item => item.CartId == user.Cart.Id)
            .ToListAsync(stoppingToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: Items in {Username}'s cart retrieved in {Duration}ms.", Source, user.Username, stopwatch.ElapsedMilliseconds);
        return items;
    }
}