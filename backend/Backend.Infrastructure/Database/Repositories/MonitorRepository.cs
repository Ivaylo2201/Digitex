using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Infrastructure.Database.Repositories;

public class MonitorRepository(DatabaseContext context) : IMonitorRepository
{
    public async Task<Monitor?> GetOneAsync(Guid id) 
        => await context.Monitors.Where(monitor => monitor.Id == id).FirstOrDefaultAsync();
    
    public async Task<IEnumerable<Monitor>> GetAllAsync()
        => await context.Monitors.ToListAsync();
}