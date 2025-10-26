using System.Diagnostics;
using System.Linq.Expressions;
using Backend.Domain.Interfaces.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Generic;

public class SingleReadableRepository<TEntity, TKey>(ILogger logger, DatabaseContext context) : ISingleReadable<TEntity, TKey> where TEntity : class
{
    private readonly string _source = $"{nameof(SingleReadableRepository<TEntity, TKey>)}<{typeof(TEntity).Name}, {typeof(TKey).Name}>";
    private readonly Type _entityType = typeof(TEntity);
    
    public async Task<TEntity?> GetOneAsync(TKey id, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include, CancellationToken cancellationToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Getting {EntityName} entity with Id={EntityId}", _source, _entityType.Name, id);

        var queryable = context.Set<TEntity>().AsNoTracking();

        if (include is not null)
            queryable = include(queryable);
        
        var entity = await queryable.FirstOrDefaultAsync(GetEqualityLambda(id), cancellationToken);

        if (entity is null)
        {
            logger.LogError("[{Source}]: {EntityName} entity with Id={EntityId} not found.", _source, _entityType.Name, id);
            return null;
        }
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: {EntityName} entity with Id={EntityId} retrieved in {Duration}ms.", _source, _entityType.Name, id, stopwatch.ElapsedMilliseconds);
        return entity;
    }
    
    private Expression<Func<TEntity,bool>> GetEqualityLambda(TKey id)
    {
        var parameter = Expression.Parameter(_entityType, "entity");
        var key = _entityType.GetProperties().FirstOrDefault(property => property.Name.Equals("Id", StringComparison.OrdinalIgnoreCase));

        if (key is null)
            throw new InvalidOperationException($"Improperly configured - {_entityType.Name} has no Id property.");
        
        var body = Expression.Equal(Expression.Property(parameter, key), Expression.Convert(Expression.Constant(id), key.PropertyType));
        return Expression.Lambda<Func<TEntity, bool>>(body, parameter);
    }
}