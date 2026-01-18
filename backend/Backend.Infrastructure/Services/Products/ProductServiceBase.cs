using System.Net;
using Backend.Application.Contracts.Product;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class ProductServiceBase<TProduct, TProjection>(
    ILogger logger,
    IProductRepository<TProduct> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService) : IProductService<TProduct, TProjection> where TProduct : ProductBase
{
    private readonly string _entityName = typeof(TProduct).Name;
    private readonly string _projectionName = typeof(TProjection).Name;

    public async Task<Result<TProjection?>> GetOneAsync(Guid id, Func<TProduct, TProjection> project, CurrencyIsoCode currencyIsoCode, CancellationToken stoppingToken = default)
    {
        var source = GetType().Name;
        var product = await productRepository.GetOneAsync(id, stoppingToken);

        if (product is null)
        {
            logger.LogWarning("[{Source}]: {Entity} with Id={Id} was not found.", source, _entityName, id);
            return Result<TProjection?>.Failure(HttpStatusCode.NotFound);
        }
        
        logger.LogInformation("[{Source}]: Projecting {Entity} into a {Projection}...", source, _entityName, _projectionName);
        var rate = await exchangeRepository.GetRateAsync(CurrencyIsoCode.Eur, currencyIsoCode, stoppingToken);
        var projection = project(currencyService.ConvertPrice(product, entity => entity.InitialPrice *= rate));
        
        return Result<TProjection?>.Success(HttpStatusCode.OK, projection);
    }

    public async Task<Result<PaginatedResponse<IReadOnlyList<ProductSummary>>>> ListAllAsync(int page, int pageSize, Query<TProduct> query, CurrencyIsoCode currencyIsoCode, CancellationToken stoppingToken = default)
    {
        var source = GetType().Name;
        var entities = await productRepository.ListAllAsync(page, pageSize, query, stoppingToken);
        
        logger.LogInformation("[{Source}]: Projecting {Count} {Entity} entities into {Projection}...", source, entities.Count, _entityName, _projectionName);
        
        var rate = await exchangeRepository.GetRateAsync(CurrencyIsoCode.Eur, currencyIsoCode, stoppingToken);

        var projections = currencyService
            .ConvertPrices(entities, entity => entity.InitialPrice *= rate)
            .Adapt<IReadOnlyList<ProductSummary>>();
        
        var totalItems = await productRepository.CountAsync(query, stoppingToken);

        var response = new PaginatedResponse<IReadOnlyList<ProductSummary>>
        {
            Items = projections,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
        };

        return Result<PaginatedResponse<IReadOnlyList<ProductSummary>>>.Success(HttpStatusCode.OK, response);
    }
}