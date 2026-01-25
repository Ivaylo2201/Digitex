using System.Net;
using Backend.Application.DTOs;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Carts.GetCart;

public class GetCartRequestHandler(
    ILogger<GetCartRequestHandler> logger,
    ICartRepository cartRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService) : IRequestHandler<GetCartRequest, Result<GetCartResponse>>
{
    public async Task<Result<GetCartResponse>> Handle(GetCartRequest request, CancellationToken cancellationToken)
    {
        var cart = await cartRepository.GetCartAsync(request.UserId, cancellationToken);
        
        if (cart is null)
            return Result<GetCartResponse>.Failure(HttpStatusCode.NotFound);
        
        var rate = await exchangeRepository.GetRateAsync(CurrencyIsoCode.Eur, request.CurrencyIsoCode, cancellationToken);
        var converted = currencyService.ConvertPrices(cart.Items, item => item.Product.InitialPrice *= rate);
        
        return Result<GetCartResponse>.Success(HttpStatusCode.OK, new GetCartResponse
        {
            Items = converted.Adapt<IEnumerable<ItemDto>>(),
            TotalPrice = cart.Items.Sum(item => item.Price)
        });
    }
}