using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;

public interface ICartRepository
{
    Task<Cart?> GetCartForUserAsync(int userId, CancellationToken stoppingToken = default);
}