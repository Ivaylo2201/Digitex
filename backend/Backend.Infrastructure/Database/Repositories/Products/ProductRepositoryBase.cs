using System.Diagnostics;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class ProductRepositoryBase<TEntity>(ILogger logger, DatabaseContext context) : IProductRepository<TEntity> where TEntity : ProductBase
{
    private readonly string _entity = typeof(TEntity).Name;
    
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

    public async Task UpdateRatingAsync(Guid id, int newRating, CancellationToken stoppingToken = default)
    {
        var source = GetType().Name;
        var stopwatch = Stopwatch.StartNew();
        
        var entity = await context.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id, stoppingToken);

        if (entity is null)
            return;
        
        entity.Rating = newRating;
        await context.SaveChangesAsync(stoppingToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: The rating of {Entity} entity with Id={Id} has been updated to {NewRating}", source, _entity, id, newRating);
    }
}