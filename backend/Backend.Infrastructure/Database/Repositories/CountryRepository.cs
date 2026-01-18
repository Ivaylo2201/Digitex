using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class CountryRepository(DatabaseContext context) : ICountryRepository
{
    public async Task<List<Country>> GetAllAsync(CancellationToken cancellationToken = default)
        => await context.Countries.AsNoTracking().ToListAsync(cancellationToken);
}