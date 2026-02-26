using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetOrdersByUserIdAsync(int userId, CancellationToken cancellationToken);
}