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
    
    public async Task<List<TEntity>> ListAllAsync(CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Retrieving all {EntityName} entities...", _source, _entityType.Name);
        var entities = await context.Set<TEntity>().ToListAsync(stoppingToken);
        
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: Retrieved {Count} {EntityName} entities in {Duration}ms.", _source, entities.Count, _entityType.Name, stopwatch.ElapsedMilliseconds);
        return entities;
    }

    public async Task<TEntity?> GetOneAsync(TKey id, CancellationToken stoppingToken = default)
    {
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Getting {EntityName} entity with Id={EntityId}", _source, _entityType.Name, id);
        
        var entity = await context.Set<TEntity>().FirstOrDefaultAsync(GetEqualityLambda(id), stoppingToken);
        
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