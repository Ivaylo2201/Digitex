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
        var queryType = typeof(TQuery).Name;
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Executing {QueryType} with Id={EntityId}...", source, queryType, query.EntityId);
        var entity = await repository.GetOneAsync(query.EntityId, stoppingToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: {QueryType} executed in {Duration}ms.", source, queryType, stopwatch.ElapsedMilliseconds);
        
        return Result<TEntity?>.Success(entity);
    }
}