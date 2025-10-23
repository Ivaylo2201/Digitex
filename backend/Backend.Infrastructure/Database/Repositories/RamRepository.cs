using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class RamRepository(DatabaseContext context) : IRamRepository
{
    public async Task<Ram?> GetOneAsync(Guid id)
        => await context.Rams.Where(ram => ram.Id == id).FirstOrDefaultAsync();
    
    public async Task<IEnumerable<Ram>> GetAllAsync() 
        => await context.Rams.ToListAsync();
}