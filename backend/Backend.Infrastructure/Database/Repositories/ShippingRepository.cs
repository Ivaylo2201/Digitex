using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class ShippingRepository(DatabaseContext context) : IShippingRepository
{
    public async Task<Shipping?> GetOneAsync(int id) 
        => await context.Shippings.Where(shipping => shipping.Id == id).FirstOrDefaultAsync();
    
    public async Task<IEnumerable<Shipping>> GetAllAsync() 
        => await context.Shippings.ToListAsync();
}