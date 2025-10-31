using Backend.Application.DTOs.Product;
using Backend.Application.Extensions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Base;

public class ProductServiceBase<TEntity, TProjection>(
    ILogger logger,
    IProductRepository<TEntity> productRepository) : IProductService<TEntity, TProjection> where TEntity : ProductBase
{
    private readonly string _entityName = typeof(TEntity).Name;
    private readonly string _projectionName = typeof(TProjection).Name;
    
    public async Task<Result<TProjection?>> GetOneAsync(Guid id, Func<TEntity, TProjection> project, CancellationToken stoppingToken = default)
    {
        var source = GetType().Name;
        var entity = await productRepository.GetOneAsync(id, stoppingToken);
        
        if (entity is null)
            return Result<TProjection?>.Failure(ErrorType.NotFound);
        
        logger.LogInformation("[{Source}]: Projecting {Entity} entity into {Projection}...", source, _entityName, _projectionName);
        return Result<TProjection?>.Success(project(entity));   
    }

    public async Task<Result<List<ProductShortDto>>> ListAllAsync(Filter<TEntity> filter, CancellationToken stoppingToken = default)
    {
        var source = GetType().Name;
        var entities = await productRepository.ListAllAsync(filter, stoppingToken);
        
        logger.LogInformation("[{Source}]: Projecting {Count} {Entity} entities into {Projection}...", source, entities.Count, _entityName, _projectionName);
        var projections = entities.Select(entity => entity.ToProductDto()).ToList();
        
        return Result<List<ProductShortDto>>.Success(projections);   
    }
}