using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class OrderRepository(DatabaseContext context) : IOrderRepository
{
    public async Task<List<Order>> GetOrdersByUserIdAsync(int userId, CancellationToken cancellationToken)
    {
        return await context.Orders.Where(order => order.UserId == userId).ToListAsync(cancellationToken);
    }
}