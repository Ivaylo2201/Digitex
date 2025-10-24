using System.Diagnostics;
using Backend.Application.CQRS.Generic.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Generics;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Generic.Handlers;

public abstract class GetEntityQueryHandlerBase<TQuery, TEntity, TKey>(
    ILogger logger,
    IReadable<TEntity, TKey> repository) : IQueryHandler<TQuery, Result<TEntity?>> where TQuery : GetEntityQuery<TEntity, TKey>
{
    private readonly string _queryName = typeof(TQuery).Name;
    
    public async Task<Result<TEntity?>> HandleAsync(TQuery query, CancellationToken stoppingToken)
    {
        var source = GetType().Name;
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Executing {QueryName} with Id={EntityId}...", source, _queryName, query.EntityId);
        var entity = await repository.GetOneAsync(query.EntityId, stoppingToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: {QueryName} executed in {Duration}ms.", source, _queryName, stopwatch.ElapsedMilliseconds);
        
        return Result<TEntity?>.Success(entity);
    }
}