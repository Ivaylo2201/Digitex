using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class SsdRepository(DatabaseContext context) : ISsdRepository
{
    public async Task<Ssd?> GetOneAsync(Guid id) 
        => await context.Ssds.Where(ssd => ssd.Id == id).FirstOrDefaultAsync();
    
    public async Task<IEnumerable<Ssd>> ListAllAsync()
        => await context.Ssds.ToListAsync();
}