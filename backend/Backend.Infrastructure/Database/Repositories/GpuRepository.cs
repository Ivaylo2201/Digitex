using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

using Gpu = Domain.Entities.Gpu;

public class GpuRepository(DatabaseContext context) : IGpuRepository
{
    public async Task<Gpu?> GetOneAsync(Guid id) 
        => await context.Gpus.Where(gpu => gpu.Id == id).FirstOrDefaultAsync();
    
    public async Task<IEnumerable<Gpu>> ListAllAsync() 
        => await context.Gpus.ToListAsync();
}