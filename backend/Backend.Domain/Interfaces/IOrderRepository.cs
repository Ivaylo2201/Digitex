using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetOrdersByUserIdAsync(int userId, CancellationToken cancellationToken);
    Task<Order> CreateAsync(int userId, int shipmentId, ICollection<Item> items, CancellationToken cancellationToken);
}