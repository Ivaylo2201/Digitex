using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces;

public interface IItemRepository : ICreatable<Item>, IDeletable<int>
{
    Task<bool> UserOwnsItemAsync(int userId, int itemId, CancellationToken stoppingToken = default);
}