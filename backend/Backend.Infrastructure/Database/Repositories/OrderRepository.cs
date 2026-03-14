using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class OrderRepository(DatabaseContext context) : IOrderRepository
{
    public async Task<List<Order>> GetOrdersByUserIdAsync(int userId, CancellationToken cancellationToken)
    {
        return await context.Orders
            .Include(order => order.Shipment)
            .Include(order => order.Address)
            .ThenInclude(address => address.City)
            .ThenInclude(city => city.Country)
            .Include(order => order.Items)
            .ThenInclude(item => item.Product)
            .ThenInclude(product => product.Brand)
            .Where(order => order.UserId == userId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Order> CreateAsync(int userId, int addressId, int shipmentId, ICollection<Item> items, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            AddressId = addressId,
            UserId = userId,
            ShipmentId = shipmentId
        };
        
        await context.Orders.AddAsync(order, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        foreach (var item in items)
        {
            item.OrderId = order.Id;
            item.CartId = null;
        }
        
        await context.SaveChangesAsync(cancellationToken);

        return await context.Orders
            .Include(o => o.Items)
            .ThenInclude(item => item.Product)
            .ThenInclude(product => product.Brand)
            .FirstAsync(o => o.Id == order.Id, cancellationToken);
    }
}