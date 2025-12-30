using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class ProductRepositoryBase<TProduct>(DatabaseContext context) : IProductRepository<TProduct> where TProduct : ProductBase
{
    public async Task<TProduct?> GetOneAsync(Guid id, CancellationToken stoppingToken = default)
        => await context
            .Set<TProduct>()
            .AsNoTracking()
            .Include(product => product.Brand)
            .Include(product => product.Suggestions)
            .ThenInclude(suggestion => suggestion.Brand)
            .Include(product => product.Reviews)
            .ThenInclude(review => review.User)
            .FirstOrDefaultAsync(product => product.Id == id, stoppingToken);

    public async Task<int> CountAsync(Query<TProduct>? filter = null, CancellationToken stoppingToken = default)
    {
        var queryable = context.Set<TProduct>().AsNoTracking();

        if (filter is not null)
            queryable = filter(queryable);

        return await queryable.CountAsync(stoppingToken);
    }

    public async Task<List<TProduct>> ListAllAsync(int page, int pageSize, Query<TProduct>? filter, CancellationToken stoppingToken = default)
    {
        var queryable = context
            .Set<TProduct>()
            .AsNoTracking()
            .Include(product => product.Brand)
            .Where(product => product.Quantity > 0);

        if (filter is not null)
            queryable = filter(queryable);
        
        return await queryable
            .Skip((Math.Max(page, 1) - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(stoppingToken);
    }
    
    public async Task<List<TProduct>> AdminListAllAsync(CancellationToken stoppingToken = default) 
        => await context
            .Set<TProduct>()
            .AsNoTracking()
            .Include(product => product.Brand)
            .ToListAsync(stoppingToken);
}