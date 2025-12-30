using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;

public interface ICartRepository
{
    Task AddToCartAsync(Item item, CancellationToken stoppingToken);
    Task<Cart?> GetCartAsync(int userId, CancellationToken stoppingToken);
}