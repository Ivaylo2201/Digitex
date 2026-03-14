using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces.Repositories;

public interface IOrderRepository
{
    Task<List<Order>> GetOrdersByUserIdAsync(int userId, CancellationToken cancellationToken);
    Task<Order> CreateAsync(int userId, int addressId, int shipmentId, ICollection<Item> items, CancellationToken cancellationToken);
}