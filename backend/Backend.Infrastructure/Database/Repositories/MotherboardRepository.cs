using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class MotherboardRepository(DatabaseContext context) : IMotherboardRepository
{
    public async Task<Motherboard?> GetOneAsync(Guid id) 
        => await context.Motherboards.Where(motherboard => motherboard.Id == id).FirstOrDefaultAsync();
    
    public async Task<IEnumerable<Motherboard>> GetAllAsync() 
        => await context.Motherboards.ToListAsync();
}