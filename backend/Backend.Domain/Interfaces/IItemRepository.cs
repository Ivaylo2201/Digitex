using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces;

public interface IItemRepository : ICreatable<Item>, ISingleReadable<Item, int>
{
    Task<List<Item>?> ListItemsInCartAsync(int userId, CancellationToken stoppingToken = default);
}