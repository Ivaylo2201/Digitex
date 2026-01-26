using System.Linq.Expressions;
using System.Net;
using Backend.Application.DTOs.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public abstract class ProductServiceBase<TProduct, TProjection>(
    ILogger logger,
    IProductRepository<TProduct> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService,
    IValidator<TProduct> validator) : IProductService<TProduct, TProjection> where TProduct : ProductBase
{
    public async Task<Result<TProjection?>> GetOneAsync(Guid id, CurrencyIsoCode currency, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetOneAsync(id, cancellationToken);

        if (product is null)
            return Result<TProjection?>.Failure(HttpStatusCode.NotFound);
        
        var rate = await exchangeRepository.GetRateAsync(CurrencyIsoCode.Eur, currency, cancellationToken);
        var projection = currencyService.ConvertPrice(product, p => p.InitialPrice *= rate).Adapt<TProjection>();
        
        return Result<TProjection?>.Success(HttpStatusCode.OK, projection);
    }

    public async Task<Result<Pagination<ProductSummaryDto>>> GetAllAsync(int page, int pageSize, CurrencyIsoCode currency, Expression<Func<TProduct, bool>> filter, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAllAsync(page, pageSize, filter, cancellationToken);
        var filteredProductsCount = await productRepository.CountAsync(filter, cancellationToken);
        
        var rate = await exchangeRepository.GetRateAsync(CurrencyIsoCode.Eur, currency, cancellationToken);
        var projections = currencyService.ConvertPrices(products, p => p.InitialPrice *= rate).Adapt<IEnumerable<ProductSummaryDto>>();

        return Result<Pagination<ProductSummaryDto>>.Success(HttpStatusCode.OK, new Pagination<ProductSummaryDto>
        {
            Items = projections,
            TotalItems = filteredProductsCount,
            TotalPages = (int)Math.Ceiling(filteredProductsCount / (double)pageSize)
        });
    }

    public async Task<Result<TProjection>> CreateAsync(TProduct product, CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(product, cancellationToken);
        
        if (!result.IsValid)
            return Result<TProjection>.Failure(HttpStatusCode.BadRequest);

        var createdProduct = await productRepository.CreateAsync(product, cancellationToken);
        return Result<TProjection>.Success(HttpStatusCode.Created, createdProduct.Adapt<TProjection>());
    }

    public async Task<Result<Unit>> UpdateAsync(Guid id, TProduct product, CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(product, cancellationToken);
        
        if (!result.IsValid)
            return Result<Unit>.Failure(HttpStatusCode.BadRequest);
        
        await productRepository.UpdateAsync(id, product, cancellationToken);
        return Result<Unit>.Success(HttpStatusCode.OK, Unit.Value);
    }

    public async Task<Result<Unit>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await productRepository.DeleteAsync(id, cancellationToken);
        return Result<Unit>.Success(HttpStatusCode.NoContent, Unit.Value);
    }
}