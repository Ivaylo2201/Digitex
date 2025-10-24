using System.Diagnostics;
using Backend.Application.Generic.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Generics;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.Generic.Handlers;

public abstract class GetEntityQueryHandlerBase<TQuery, TEntity, TKey>(
    ILogger logger,
    IReadable<TEntity, TKey> repository) : IQueryHandler<TQuery, Result<TEntity?>> where TQuery : GetEntityQuery<TEntity, TKey>
{
    public async Task<Result<TEntity?>> HandleAsync(TQuery query, CancellationToken stoppingToken)
    {
        var source = GetType().Name;
        var entityType = typeof(TEntity).Name;
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Getting {EntityType} entity with Id={EntityId}", source, entityType, query.EntityId);
        var entity = await repository.GetOneAsync(query.EntityId, stoppingToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: {EntityType} entity with Id={EntityId} retrieved in {Duration}ms.", source, entityType, query.EntityId, stopwatch.ElapsedMilliseconds);
        return Result<TEntity?>.Success(entity);
    }
}