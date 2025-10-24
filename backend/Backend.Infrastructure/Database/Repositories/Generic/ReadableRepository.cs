using System.Diagnostics;
using System.Linq.Expressions;
using Backend.Domain.Interfaces.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Generic;

public class ReadableRepository<TEntity, TKey>(ILogger logger, DatabaseContext context) : IReadable<TEntity, TKey> where TEntity : class, IEntity<TKey>
{
    private readonly string _source = $"{nameof(ReadableRepository<TEntity, TKey>)}<{typeof(TEntity).Name}, {typeof(TKey).Name}>";
    private readonly Type _entityType = typeof(TEntity);
    
    public async Task<List<TEntity>> ListAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include, CancellationToken cancellationToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        context.Gpus.Include(gpu => gpu.Brand);
        
        logger.LogInformation("[{Source}]: Retrieving all {EntityName} entities...", _source, _entityType.Name);
        
        IQueryable<TEntity> queryable = context.Set<TEntity>();

        if (include is not null)
            queryable = include(queryable);
        
        var entities = await queryable.ToListAsync(cancellationToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: Retrieved {Count} {EntityName} entities in {Duration}ms.", _source, entities.Count, _entityType.Name, stopwatch.ElapsedMilliseconds);
        return entities;
    }

    public async Task<TEntity?> GetOneAsync(TKey id, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include, CancellationToken cancellationToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Getting {EntityName} entity with Id={EntityId}", _source, _entityType.Name, id);
        
        IQueryable<TEntity> queryable = context.Set<TEntity>();

        if (include is not null)
            queryable = include(queryable);
        
        var entity = await queryable.FirstOrDefaultAsync(GetEqualityLambda(id), cancellationToken);

        if (entity is null)
        {
            logger.LogWarning("[{Source}]: {EntityName} entity with Id={EntityId} not found.", _source, _entityType.Name, id);
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