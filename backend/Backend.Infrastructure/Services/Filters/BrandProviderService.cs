using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Services.Filters;

public class BrandProviderService<TEntity>(IProductRepository<TEntity> productRepository)
    : IBrandProviderService<TEntity> where TEntity : ProductBase
{
    public List<string> Brands
        => productRepository
            .GetContextSet()
            .Include(entity => entity.Brand)
            .Select(entity => entity.Brand.BrandName)
            .Distinct()
            .ToList();
}