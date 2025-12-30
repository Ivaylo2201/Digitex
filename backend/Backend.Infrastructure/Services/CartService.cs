using Backend.Application.Contracts.Cart.AddToCart;
using Backend.Application.Contracts.Cart.GetCart;
using Backend.Application.Extensions;
using Backend.Application.Interfaces;
using Backend.Application.Validators;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Item = Backend.Domain.Entities.Item;

namespace Backend.Infrastructure.Services;

public class CartService(
    ILogger<CartService> logger,
    ICurrencyService currencyService,
    ICartRepository cartRepository,
    IUserRepository userRepository,
    IExchangeRepository exchangeRepository) : ICartService
{
    private const string Source = nameof(CartService);

    public async Task<Result<AddToCartResponse>> AddToCartAsync(AddToCartRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{Source}]: Validating AddToCart request body...", Source);
        var validationResult = await new AddToCartValidator().ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            return Result<AddToCartResponse>.Failure(StatusCodes.Status400BadRequest, ErrorType.ValidationFailed, validationResult.GetStringifiedErrors(Source));
        
        var user = await userRepository.GetOneByIdWithCartAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            logger.LogWarning("[{Source}]: No verified user was found by Id.", Source);
            return Result<AddToCartResponse>.Failure(StatusCodes.Status404NotFound);
        }
        
        await cartRepository.AddToCartAsync(new Item
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            CartId = user.Cart.Id
        }, cancellationToken);
        
        return Result<AddToCartResponse>.Success(StatusCodes.Status201Created, new AddToCartResponse());
    }

    public async Task<Result<GetCartResponse>> GetCartAsync(GetCartRequest request, CancellationToken cancellationToken)
    {
        var cart = await cartRepository.GetCartAsync(request.UserId, cancellationToken);
        
        if (cart is null)
            return Result<GetCartResponse>.Failure(StatusCodes.Status404NotFound);
        
        var rate = await exchangeRepository.GetRateAsync(CurrencyIsoCode.Eur, request.CurrencyIsoCode, cancellationToken);
        var converted = currencyService.ConvertPrices(cart.Items, item => item.Product.InitialPrice *= rate);
        
        return Result<GetCartResponse>.Success(StatusCodes.Status200OK, new GetCartResponse
        {
            Items = converted.Adapt<List<ItemProjection>>(),
            TotalPrice = cart.Items.Sum(item => item.Price)
        });
    }
}