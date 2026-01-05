using Backend.Application.Contracts.Cart.AddToCart;
using Backend.Application.Contracts.Cart.GetCart;
using Backend.Application.Contracts.Cart.RemoveFromCart;
using Backend.Application.Contracts.Cart.UpdateItemQuantity;
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
    IExchangeRepository exchangeRepository,
    IItemRepository itemRepository) : ICartService
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

    public async Task<Result> RemoveFromCartAsync(RemoveFromCartRequest removeFromCartRequest, CancellationToken cancellationToken)
    {
        var hasPermission = await HasItemPermissionAsync(removeFromCartRequest.ItemId, removeFromCartRequest.UserId, cancellationToken);
        
        if (!hasPermission.IsSuccess)
            return hasPermission;

        await itemRepository.DeleteAsync(removeFromCartRequest.ItemId, cancellationToken);
        return Result.Success(StatusCodes.Status204NoContent);
    }

    public async Task<Result> UpdateItemQuantityAsync(UpdateItemQuantityRequest updateItemQuantityRequest, CancellationToken cancellationToken)
    {
        var hasPermission = await HasItemPermissionAsync(updateItemQuantityRequest.ItemId, updateItemQuantityRequest.UserId, cancellationToken);
        
        if (!hasPermission.IsSuccess)
            return hasPermission;
        
        var product = (await itemRepository.GetOneByIdWithProductAsync(updateItemQuantityRequest.ItemId, cancellationToken))?.Product;
        
        if (product is null)
            return Result.Failure(StatusCodes.Status404NotFound);
        
        if (product.Quantity < updateItemQuantityRequest.NewQuantity)
            return Result.Failure(StatusCodes.Status400BadRequest);

        await itemRepository.UpdateQuantityAsync(
            updateItemQuantityRequest.ItemId,
            updateItemQuantityRequest.NewQuantity,
            cancellationToken);

        return Result.Success(StatusCodes.Status200OK);
    }

    private async Task<Result> HasItemPermissionAsync(int itemId, int userId, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetOneAsync(userId, cancellationToken);
        var item = await itemRepository.GetOneByIdWithCartAsync(itemId, cancellationToken);
        
        if (user is null || item is null)
            return Result.Failure(StatusCodes.Status404NotFound);
            
        if (item.Cart.User.Id != userId)
            return Result.Failure(StatusCodes.Status403Forbidden);
        
        return Result.Success(StatusCodes.Status200OK);
    }
}