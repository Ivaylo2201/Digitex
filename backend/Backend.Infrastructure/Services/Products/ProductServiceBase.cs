using Backend.Application.Dtos.Product;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class ProductServiceBase<TEntity, TProjection>(
    ILogger logger,
    IProductRepository<TEntity> productRepository,
    IExchangeRateRepository exchangeRateRepository) : IProductService<TEntity, TProjection> where TEntity : ProductBase
{
    private readonly string _entityName = typeof(TEntity).Name;
    private readonly string _projectionName = typeof(TProjection).Name;

    public async Task<Result<TProjection?>> GetOneAsync(Guid id, Func<TEntity, TProjection> project, CurrencyIsoCode currencyIsoCode, CancellationToken stoppingToken = default)
    {
        var source = GetType().Name;
        var entity = await productRepository.GetOneAsync(id, stoppingToken);

        if (entity is null)
        {
            logger.LogWarning("[{Source}]: {Entity} with Id={Id} was not found.", source, _entityName, id);
            return Result<TProjection?>.Failure(StatusCodes.Status404NotFound);
        }
        
        logger.LogInformation("[{Source}]: Projecting {Entity} into a {Projection}...", source, _entityName, _projectionName);

        if (currencyIsoCode is CurrencyIsoCode.Eur)
            return Result<TProjection?>.Success(StatusCodes.Status200OK, project(entity));

        var exchangeRate = await exchangeRateRepository.GetOneAsync(CurrencyIsoCode.Eur, currencyIsoCode, stoppingToken);
        entity.InitialPrice *= exchangeRate?.Rate ?? 1;
        
        return Result<TProjection?>.Success(StatusCodes.Status200OK, project(entity));
    }

    public async Task<Result<PaginatedResponse<List<ProductShortDto>>>> ListAllAsync(int page, int pageSize, Query<TEntity> query, CurrencyIsoCode currencyIsoCode, CancellationToken stoppingToken = default)
    {
        var source = GetType().Name;
        var entities = await productRepository.ListAllAsync(page, pageSize, query, stoppingToken);
        
        logger.LogInformation("[{Source}]: Projecting {Count} {Entity} entities into {Projection}...", source, entities.Count, _entityName, _projectionName);
        
        var rate = currencyIsoCode is CurrencyIsoCode.Eur ? 1 : (await exchangeRateRepository.GetOneAsync(CurrencyIsoCode.Eur, currencyIsoCode, stoppingToken))?.Rate ?? 1;

        var projections = entities.Select(entity =>
        {
            entity.InitialPrice *= rate;
            return entity.Adapt<ProductShortDto>();
        }).ToList();
        
        var totalItems = await productRepository.CountAsync(query, stoppingToken);

        var response = new PaginatedResponse<List<ProductShortDto>>
        {
            Items = projections,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
        };

        return Result<PaginatedResponse<List<ProductShortDto>>>.Success(StatusCodes.Status200OK, response);
    }
}