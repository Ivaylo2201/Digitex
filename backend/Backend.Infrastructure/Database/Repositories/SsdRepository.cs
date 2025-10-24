using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class SsdRepository(DatabaseContext context) : ISsdRepository
{
    public async Task<Ssd?> GetOneAsync(Guid id, CancellationToken stoppingToken = default) 
        => await context.Ssds.Where(ssd => ssd.Id == id).FirstOrDefaultAsync(stoppingToken);
    
    public async Task<List<Ssd>> ListAllAsync(CancellationToken stoppingToken = default)
        => await context.Ssds.ToListAsync(stoppingToken);
}