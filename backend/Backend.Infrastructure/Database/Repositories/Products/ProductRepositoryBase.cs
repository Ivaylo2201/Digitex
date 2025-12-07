using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class ProductRepositoryBase<TEntity>(DatabaseContext context)
    : IProductRepository<TEntity> where TEntity : ProductBase
{
    public async Task<TEntity?> GetOneAsync(Guid id, CancellationToken stoppingToken = default)
        => await context
            .Set<TEntity>()
            .AsNoTracking()
            .Include(entity => entity.Brand)
            .Include(entity => entity.Suggestions)
            .ThenInclude(suggestion => suggestion.Brand)
            .Include(entity => entity.Reviews)
            .ThenInclude(review => review.User)
            .FirstOrDefaultAsync(entity => entity.Id == id, stoppingToken);
    

    public async Task<List<TEntity>> ListAllAsync(Filter<TEntity>? filter, CancellationToken stoppingToken = default)
    {
        var queryable = context
            .Set<TEntity>()
            .AsNoTracking()
            .Include(entity => entity.Brand)
            .Where(entity => entity.Quantity > 0);

        if (filter is not null)
            queryable = filter(queryable);
        
        return await queryable.ToListAsync(stoppingToken);
    }
}