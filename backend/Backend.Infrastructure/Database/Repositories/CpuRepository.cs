using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class CpuRepository(DatabaseContext context) : ICpuRepository
{
    public async Task<Cpu?> GetOneAsync(Guid id, CancellationToken stoppingToken = default) 
        => await context.Cpus.Where(cpu => cpu.Id == id).FirstOrDefaultAsync(stoppingToken);
    
    public async Task<List<Cpu>> ListAllAsync(CancellationToken stoppingToken = default) 
        => await context.Cpus.ToListAsync(stoppingToken);
}