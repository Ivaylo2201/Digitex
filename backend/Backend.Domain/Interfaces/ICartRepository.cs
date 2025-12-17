using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;

public interface ICartRepository
{
    Task<double> GetCartTotalAsync(int userId, CancellationToken stoppingToken = default);
    Task AddToCartAsync(Item item, CancellationToken stoppingToken);
}