using System.Diagnostics;
using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.Extensions;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Generics;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Generic.Handlers;

public abstract class ListEntitiesQueryHandlerBase<TQuery, TEntity, TProjection>(
    ILogger logger,
    IMultipleReadable<TEntity> repository) : IQueryHandler<TQuery, Result<List<TProjection>>> where TQuery : ListEntitiesQueryBase<TEntity, TProjection>
{
    private readonly string _queryName = typeof(TQuery).Name;
    
    public async Task<Result<List<TProjection>>> HandleAsync(TQuery query, CancellationToken ct)
    {
        var source = GetType().Name;
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogQueryExecutionStart(source, _queryName);
        var entities = await repository.ListAllAsync(query.Include, query.Filters, ct);
        var projections = entities.Select(query.Project).ToList();
        logger.LogQueryExecutionDuration(source, _queryName, stopwatch);

        return Result<List<TProjection>>.Success(projections);
    }
}