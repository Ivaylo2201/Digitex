using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Infrastructure.Database.Repositories;

public class MonitorRepository(DatabaseContext context) : IMonitorRepository
{
    public async Task<Monitor?> GetOneAsync(Guid id, CancellationToken stoppingToken = default) 
        => await context.Monitors.Where(monitor => monitor.Id == id).FirstOrDefaultAsync(stoppingToken);
    
    public async Task<List<Monitor>> ListAllAsync(CancellationToken stoppingToken = default)
        => await context.Monitors.ToListAsync(stoppingToken);
}