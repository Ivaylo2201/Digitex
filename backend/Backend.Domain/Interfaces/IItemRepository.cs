using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces;

public interface IItemRepository : ICreatable<Item>, IDeletable<int>
{
    Task<List<Item>> GetItemsInUserCartAsync(int userId, CancellationToken stoppingToken = default);
    Task<bool> IsItemOwnedByUserAsync(int itemId, int userId, CancellationToken stoppingToken = default);
}