using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Filters;

// TODO: Use IBrandRepository instead of DatabaseContext
public class BrandProviderService(ILogger<BrandProviderService> logger, DatabaseContext context) : IBrandProviderService
{
    private const string Source = nameof(BrandProviderService);
    
    public List<string> GetBrands<TEntity>() where TEntity : ProductBase
    {
        logger.LogInformation("[{Source}]: Getting {Entity} brands...", Source, typeof(TEntity).Name);
        
        return context
            .Set<TEntity>()
            .Include(entity => entity.Brand)
            .Select(entity => entity.Brand.BrandName)
            .Distinct()
            .ToList();
    }
}