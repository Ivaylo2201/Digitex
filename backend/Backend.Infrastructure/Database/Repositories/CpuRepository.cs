using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class CpuRepository(DatabaseContext context) : ICpuRepository
{
    public async Task<Cpu?> GetOneAsync(Guid id) 
        => await context.Cpus.Where(cpu => cpu.Id == id).FirstOrDefaultAsync();
    
    public async Task<IEnumerable<Cpu>> GetAllAsync() 
        => await context.Cpus.ToListAsync();
}