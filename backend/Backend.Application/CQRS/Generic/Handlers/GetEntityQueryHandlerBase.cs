using System.Diagnostics;
using Backend.Application.CQRS.Generic.Queries;
using Backend.Application.Extensions;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Generics;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Generic.Handlers;

public abstract class GetEntityQueryHandlerBase<TQuery, TEntity, TKey, TProjection>(ILogger logger, IReadable<TEntity, TKey> repository) : IQueryHandler<TQuery, Result<TProjection?>> where TQuery : GetEntityQuery<TEntity, TKey, TProjection>
{
    private readonly string _queryName = typeof(TQuery).Name;
    
    public async Task<Result<TProjection?>> HandleAsync(TQuery query, CancellationToken cancellationToken)
    {
        var source = GetType().Name;
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogQueryExecutionStart(source, _queryName, $" with Id={query.EntityId}");
        var entity = await repository.GetOneAsync(query.EntityId, query.Include, cancellationToken);
        logger.LogQueryExecutionDuration(source, _queryName, stopwatch);

        if (entity is null)
            return Result<TProjection?>.Failure(ErrorType.NotFound);       
        
        var projection = query.Project(entity);
        return Result<TProjection?>.Success(projection);   
    }
}