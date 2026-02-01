using System.Net;
using Backend.Application.Interfaces.Common;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace Backend.Application.UseCases.Products;

public class GetAllProductsRequestHandlerBase<TRequest, TProduct, TProjection>(
    IProductRepository<TProduct> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService,
    IExpressionBuilderService<TProduct> expressionBuilderService) : IRequestHandler<TRequest, Result<Pagination<TProjection>>>
    where TRequest : IRequest<Result<Pagination<TProjection>>>, IGetAllRequest
    where TProduct : ProductBase
{
    public async Task<Result<Pagination<TProjection>>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var filter = expressionBuilderService.Build(request.Criteria);
        
        var products = await productRepository.GetAllAsync(request.Page, request.PageSize, filter, cancellationToken);
        var filteredProductsCount = await productRepository.CountAsync(filter, cancellationToken);
        
        var rate = await exchangeRepository.GetRateAsync(CurrencyIsoCode.Eur, request.Currency.ToCurrencyIsoCode(), cancellationToken);
        var projections = currencyService.ConvertPrices(products, p => p.InitialPrice *= rate).Adapt<IEnumerable<TProjection>>();

        return Result<Pagination<TProjection>>.Success(HttpStatusCode.OK, new Pagination<TProjection>
        {
            Items = projections,
            TotalItems = filteredProductsCount,
            TotalPages = (int)Math.Ceiling(filteredProductsCount / (double)request.PageSize)
        });
    }
}