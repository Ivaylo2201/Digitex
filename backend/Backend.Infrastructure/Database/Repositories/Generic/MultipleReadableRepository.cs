using System.Diagnostics;
using Backend.Domain.Interfaces.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Generic;

public class MultipleReadableRepository<TEntity>(ILogger logger, DatabaseContext context)  : IMultipleReadable<TEntity> where TEntity : class
{
    private readonly string _source = $"{nameof(MultipleReadableRepository<TEntity>)}<{typeof(TEntity).Name}>";
    private readonly Type _entityType = typeof(TEntity);
    
    public async Task<List<TEntity>> ListAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include, CancellationToken cancellationToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Retrieving all {EntityName} entities...", _source, _entityType.Name);
        
        var queryable = context.Set<TEntity>().AsNoTracking();

        if (include is not null)
            queryable = include(queryable);
        
        var entities = await queryable.ToListAsync(cancellationToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: Retrieved {Count} {EntityName} entities in {Duration}ms.", _source, entities.Count, _entityType.Name, stopwatch.ElapsedMilliseconds);
        return entities;
    }
}