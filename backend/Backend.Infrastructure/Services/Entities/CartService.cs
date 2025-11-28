using Backend.Application.Dtos.Cart;
using Backend.Application.Dtos.Item;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services.Entities;

public class CartService(ICartRepository cartRepository, IItemRepository itemRepository, IProductBaseRepository productBaseRepository) : ICartService
{
    public async Task<Result> AddToCartAsync(AddToCartDto cartDto, CancellationToken stoppingToken = default)
    {
        var cart = await cartRepository.GetCartForUserAsync(cartDto.UserId, stoppingToken);

        if (cart is null)
            return Result.Failure(StatusCodes.Status404NotFound);
        
        var product = await productBaseRepository.GetOneAsync(cartDto.ProductId, stoppingToken);
        
        if (product is null)
            return Result.Failure(StatusCodes.Status404NotFound);
        
        if (cartDto.Quantity > product.Quantity)
            return Result.Failure(StatusCodes.Status400BadRequest, ErrorType.OutOfStock);
        
        var item = new Item
        {
            ProductId = cartDto.ProductId,
            Quantity = cartDto.Quantity,
            Cart = cart
        };

        await productBaseRepository.DecreaseQuantityAsync(cartDto.ProductId, stoppingToken);
        await itemRepository.CreateAsync(item, stoppingToken);
        return Result.Success(StatusCodes.Status201Created);
    }

    public async Task<Result<List<ItemDto>>> ListItemsInCartAsync(ListItemsInCartDto cartDto, CancellationToken stoppingToken = default)
    {
        var items = await itemRepository.GetItemsInUserCartAsync(cartDto.UserId, stoppingToken);
        var projections = items.Select(item => item.Adapt<ItemDto>()).ToList();
        return Result<List<ItemDto>>.Success(StatusCodes.Status200OK, projections);       
    }

    public async Task<Result> RemoveFromCartAsync(RemoveFromCartDto cartDto, CancellationToken stoppingToken = default)
    {
        await itemRepository.DeleteAsync(cartDto.ItemId, stoppingToken);
        return Result.Success(StatusCodes.Status204NoContent);       
    }
}