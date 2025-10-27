using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Base;

public class ProductServiceBase<TEntity, TProjection>(ILogger logger, IProductRepository<TEntity> repository) : IProductService<TEntity, TProjection>
{
    private readonly string _entityName = typeof(TEntity).Name;
    private readonly string _projectionName = typeof(TProjection).Name;
    
    public async Task<Result<TProjection?>> GetOneAsync(Guid id, Func<TEntity, TProjection> project, CancellationToken ct = default)
    {
        var source = GetType().Name;
        var entity = await repository.GetOneAsync(id, ct);
        
        if (entity is null)
            return Result<TProjection?>.Failure(ErrorType.NotFound);
        
        logger.LogInformation("[{Source}]: Projecting {Entity} entity into {Projection}...", source, _entityName, _projectionName);
        return Result<TProjection?>.Success(project(entity));   
    }

    public async Task<Result<List<TProjection>>> ListAllAsync(Filter<TEntity> filter, Func<TEntity, TProjection> project, CancellationToken ct = default)
    {
        var source = GetType().Name;
        var entities = await repository.ListAllAsync(filter, ct);
        
        logger.LogInformation("[{Source}]: Projecting {Count} {Entity} entities into {Projection}...", source, entities.Count, _entityName, _projectionName);
        var projections = entities.Select(project).ToList();
        
        return Result<List<TProjection>>.Success(projections);   
    }
}