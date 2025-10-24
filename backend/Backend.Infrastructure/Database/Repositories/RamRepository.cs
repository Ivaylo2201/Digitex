using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class RamRepository(DatabaseContext context) : IRamRepository
{
    public async Task<Ram?> GetOneAsync(Guid id, CancellationToken stoppingToken = default)
        => await context.Rams.Where(ram => ram.Id == id).FirstOrDefaultAsync(stoppingToken);
    
    public async Task<List<Ram>> ListAllAsync(CancellationToken stoppingToken = default) 
        => await context.Rams.ToListAsync(stoppingToken);
}