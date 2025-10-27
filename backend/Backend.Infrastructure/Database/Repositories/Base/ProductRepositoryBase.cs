using System.Diagnostics;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Base;

public class ProductRepositoryBase<TEntity>(ILogger logger, DatabaseContext context) : IProductRepository<TEntity> where TEntity : ProductBase
{
    private readonly string _entity = typeof(TEntity).Name;
    
    public async Task<TEntity?> GetOneAsync(Guid id, CancellationToken ct = default)
    {
        var source = GetType().Name;
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Getting {Entity} entity with Id of {EntityId}...", source, _entity, id);
        
        var entity = await context
            .Set<TEntity>()
            .AsNoTracking()
            .Include(entity => entity.Brand)
            .Include(entity => entity.Reviews)
            .ThenInclude(review => review.User)
            .FirstOrDefaultAsync(entity => entity.Id == id, ct);
        
        stopwatch.Stop();

        if (entity is null)
        {
            logger.LogWarning("[{Source}]: {Entity} entity not found in {Duration}ms", source, _entity, stopwatch.ElapsedMilliseconds);
        }
        else
        {
            logger.LogInformation("[{Source}]: {Entity} entity found in {Duration}ms", source, _entity, stopwatch.ElapsedMilliseconds);
        }
        
        return entity;
    }

    public async Task<List<TEntity>> ListAllAsync(Filter<TEntity>? filter, CancellationToken ct = default)
    {
        var source = GetType().Name;
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Listing {Entity} entities...", source, _entity);

        IQueryable<TEntity> queryable = context
            .Set<TEntity>()
            .AsNoTracking()
            .Include(entity => entity.Brand)
            .Include(entity => entity.Reviews);

        if (filter is not null)
            queryable = filter(queryable);
        
        var entities = await queryable.ToListAsync(ct);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: {Count} {Entity} entities listed in {Duration}ms", source, entities.Count, _entity, stopwatch.ElapsedMilliseconds);
        return entities;
    }
}