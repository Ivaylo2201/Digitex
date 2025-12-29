using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class BrandRepository(DatabaseContext context) : IBrandRepository
{
    public async Task<List<string>> ListBrandNamesAsync<TProduct>(CancellationToken stoppingToken = default) where TProduct : ProductBase
    {
        return await context
            .Set<TProduct>()
            .AsNoTracking()
            .Include(product => product.Brand)
            .Select(product => product.Brand.BrandName)
            .Distinct()
            .ToListAsync(stoppingToken);
    }
}