using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

using Gpu = Domain.Entities.Gpu;

public class GpuRepository(DatabaseContext context) : IGpuRepository
{
    public async Task<Gpu?> GetOneAsync(Guid id, CancellationToken stoppingToken = default) 
        => await context.Gpus.Where(gpu => gpu.Id == id).FirstOrDefaultAsync(stoppingToken);
    
    public async Task<List<Gpu>> ListAllAsync(CancellationToken stoppingToken = default) 
        => await context.Gpus.ToListAsync(stoppingToken);
}