using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class MotherboardRepository(DatabaseContext context) : IMotherboardRepository
{
    public async Task<Motherboard?> GetOneAsync(Guid id, CancellationToken stoppingToken = default) 
        => await context.Motherboards.Where(motherboard => motherboard.Id == id).FirstOrDefaultAsync(stoppingToken);
    
    public async Task<List<Motherboard>> ListAllAsync(CancellationToken stoppingToken = default) 
        => await context.Motherboards.ToListAsync(stoppingToken);
}