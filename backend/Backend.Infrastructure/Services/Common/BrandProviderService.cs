using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Services.Common;

public class BrandProviderService(DatabaseContext context) : IBrandProviderService
{
    public List<string> GetBrands<TEntity>() where TEntity : ProductBase
    {
        return context
            .Set<TEntity>()
            .Include(entity => entity.Brand)
            .Select(entity => entity.Brand.BrandName)
            .Distinct()
            .ToList();
    }
}