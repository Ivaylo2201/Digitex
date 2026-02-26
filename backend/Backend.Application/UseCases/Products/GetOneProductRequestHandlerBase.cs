using System.Net;
using Backend.Application.Interfaces.Common;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace Backend.Application.UseCases.Products;

public class GetOneProductRequestHandlerBase<TRequest, TProduct, TProjection>(
    IProductRepository<TProduct> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService) : IRequestHandler<TRequest, Result<TProjection?>>
    where TRequest : IRequest<Result<TProjection?>>, IGetOneRequest
    where TProduct : ProductBase
{
    public async Task<Result<TProjection?>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetOneAsync(request.Id, cancellationToken);

        if (product is null)
            return Result<TProjection?>.Failure(HttpStatusCode.NotFound);
        
        var rate = await exchangeRepository.GetRateAsync(CurrencyIsoCode.Eur, request.Currency, cancellationToken);
        var projection = currencyService.ConvertPrice(product, p => p.InitialPrice *= rate).Adapt<TProjection>();
        
        return Result<TProjection?>.Success(HttpStatusCode.OK, projection);
    }
}