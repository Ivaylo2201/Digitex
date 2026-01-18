using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class CityRepository(DatabaseContext context) : ICityRepository
{
    public async Task<List<City>> GetAllByCountryId(int countryId, CancellationToken cancellationToken)
        => await context.Cities
            .AsNoTracking()
            .Where(city => city.CountryId == countryId)
            .ToListAsync(cancellationToken);
}