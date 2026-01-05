using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;

public interface ICartRepository
{
    Task AddToCartAsync(Item item, CancellationToken stoppingToken);
    Task<Cart?> GetCartAsync(int userId, CancellationToken stoppingToken);
    Task RemoveFromCartAsync(int userId, int itemId, CancellationToken stoppingToken);
    Task UpdateItemQuantityAsync(int userId, int itemId, int quantity, CancellationToken stoppingToken);
}