using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

using Gpu = Domain.Entities.Gpu;

public class GpuRepository(DatabaseContext context) : IGpuRepository
{
    public async Task<Gpu?> GetOneAsync(Guid id) => await context.Gpus.FindAsync(id);
    public async Task<IEnumerable<Gpu>> GetAllAsync() => await context.Gpus.ToListAsync();
}