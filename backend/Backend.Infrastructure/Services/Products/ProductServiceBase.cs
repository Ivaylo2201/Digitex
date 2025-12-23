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
        
        if (currencyIsoCode is not CurrencyIsoCode.Eur)
        {
            var exchangeRate = await exchangeRateRepository.GetOneAsync(CurrencyIsoCode.Eur, currencyIsoCode, stoppingToken);
            entity.InitialPrice *= exchangeRate?.Rate ?? 1;
        }

        logger.LogInformation("[{Source}]: Projecting {Entity} into a {Projection}...", source, _entityName, _projectionName);
        return Result<TProjection?>.Success(StatusCodes.Status200OK, project(entity));
    }

    public async Task<Result<List<ProductShortDto>>> ListAllAsync(Filter<TEntity> filter, CurrencyIsoCode currencyIsoCode, CancellationToken stoppingToken = default)
    {
        var source = GetType().Name;
        var entities = await productRepository.ListAllAsync(filter, stoppingToken);

        logger.LogInformation("[{Source}]: Projecting {Count} {Entity} entities into {Projection}...", source, entities.Count, _entityName, _projectionName);
        var rate = currencyIsoCode is CurrencyIsoCode.Eur ? 1 : (await exchangeRateRepository.GetOneAsync(CurrencyIsoCode.Eur, currencyIsoCode, stoppingToken))?.Rate ?? 1;

        var projections = entities.Select(entity =>
        {
            entity.InitialPrice *= rate;
            return entity.Adapt<ProductShortDto>();
        }).ToList();

        return Result<List<ProductShortDto>>.Success(StatusCodes.Status200OK, projections);
    }

    public async Task<Result<List<TProjection>>> AdminListAllAsync(CurrencyIsoCode currencyIsoCode, CancellationToken stoppingToken = default)
    {
        var entities = await productRepository.AdminListAllAsync(stoppingToken);
        var rate = currencyIsoCode is CurrencyIsoCode.Eur ? 1 : (await exchangeRateRepository.GetOneAsync(CurrencyIsoCode.Eur, currencyIsoCode, stoppingToken))?.Rate ?? 1;
        
        var projections = entities.Select(entity =>
        {
            entity.InitialPrice *= rate;
            return entity.Adapt<TProjection>();
        }).ToList();
        
        return Result<List<TProjection>>.Success(StatusCodes.Status200OK, projections);
    }
}