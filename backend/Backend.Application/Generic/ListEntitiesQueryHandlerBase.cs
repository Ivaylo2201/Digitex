using System.Diagnostics;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Generics;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.Generic;

public abstract class ListEntitiesQueryHandlerBase<TQuery, TEntity, TKey>(
    ILogger logger,
    IReadable<TEntity, TKey> repository) : IQueryHandler<TQuery, Result<IEnumerable<TEntity>>> where TQuery : ListEntitiesQuery<TEntity>
{
    public async Task<Result<IEnumerable<TEntity>>> HandleAsync(TQuery query, CancellationToken ct)
    {
        var source = GetType().Name;
        var entityType = typeof(TEntity).Name;
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Retrieving all {EntityType} entities...", source, entityType);
        var entities = await repository.ListAllAsync();
        
        stopwatch.Stop();

        var count = entities.ToList().Count;
        var duration = stopwatch.ElapsedMilliseconds;
        
        logger.LogInformation("[{Source}]: Retrieved {Count} {EntityType} entities in {Duration}ms.", source, count, entityType, duration);
        
        return Result<IEnumerable<TEntity>>.Success(entities);
    }
}