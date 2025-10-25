using System.Diagnostics;
using Backend.Application.CQRS.Generic.Queries;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Generics;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Generic.Handlers;

public abstract class ListEntitiesQueryHandlerBase<TQuery, TEntity, TKey, TProjection>(
    ILogger logger,
    IReadable<TEntity, TKey> repository) : IQueryHandler<TQuery, Result<List<TProjection>>> where TQuery : ListEntitiesQuery<TEntity, TProjection>
{
    private readonly string _queryName = typeof(TQuery).Name;
    
    public async Task<Result<List<TProjection>>> HandleAsync(TQuery query, CancellationToken cancellationToken)
    {
        var source = GetType().Name;
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Executing {QueryName}...", source, _queryName);
        
        var entities = await repository.ListAllAsync(query.Include, cancellationToken);
        var projections = entities.Select(query.Project).ToList();
        
        stopwatch.Stop();
        
        logger.LogInformation("[{Source}]: {QueryName} executed in {Duration}ms.", source, _queryName, stopwatch.ElapsedMilliseconds);
        return Result<List<TProjection>>.Success(projections);
    }
}