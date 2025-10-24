using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class ShippingRepository(DatabaseContext context) : IShippingRepository
{
    public async Task<Shipping?> GetOneAsync(int id, CancellationToken stoppingToken = default) 
        => await context.Shippings.Where(shipping => shipping.Id == id).FirstOrDefaultAsync(stoppingToken);
    
    public async Task<List<Shipping>> ListAllAsync(CancellationToken stoppingToken = default) 
        => await context.Shippings.ToListAsync(stoppingToken);
}