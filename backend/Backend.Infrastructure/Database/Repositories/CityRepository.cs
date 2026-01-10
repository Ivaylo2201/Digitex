using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class CityRepository(DatabaseContext context) : ICityRepository
{
    public async Task<List<City>> ListAllAsync(Query<City>? filter = null,
        CancellationToken cancellationToken = default)
    {
        var cities = context.Cities.AsNoTracking();
        
        if (filter != null)
            cities = filter(cities);

        return await cities.ToListAsync(cancellationToken);
    }
}