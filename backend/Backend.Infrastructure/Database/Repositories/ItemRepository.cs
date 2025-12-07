using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class ItemRepository(DatabaseContext context) : IItemRepository
{
    public async Task<Item> CreateAsync(Item item, CancellationToken stoppingToken = default)
    {
        var entity = (await context.Items.AddAsync(item, stoppingToken)).Entity;
        await context.SaveChangesAsync(stoppingToken);
        return entity;
    }

    public async Task DeleteAsync(int id, CancellationToken stoppingToken = default)
        => await context.Items.Where(x => x.Id == id).ExecuteDeleteAsync(stoppingToken);

    public async Task<bool> UserOwnsItemAsync(int userId, int itemId, CancellationToken stoppingToken = default)
        => await context.Items.AsNoTracking().AnyAsync(x => x.Id == itemId && x.Cart.UserId == userId, stoppingToken);
}