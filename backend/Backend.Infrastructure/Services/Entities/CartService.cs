using Backend.Application.DTOs.Cart;
using Backend.Application.DTOs.Item;
using Backend.Application.Extensions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;

namespace Backend.Infrastructure.Services.Entities;

public class CartService(ICartRepository cartRepository, IItemRepository itemRepository) : ICartService
{
    public async Task<Result> AddToCartAsync(AddToCartDto cartDto, CancellationToken stoppingToken = default)
    {
        var cart = await cartRepository.GetCartForUserAsync(cartDto.UserId, stoppingToken);

        if (cart is null)
            return Result.Failure(ErrorType.NotFound);
        
        var item = new Item
        {
            ProductId = cartDto.ProductId,
            Quantity = cartDto.Quantity,
            Cart = cart
        };
        
        await itemRepository.CreateAsync(item, stoppingToken);
        return Result.Success();
    }

    public async Task<Result<List<ItemDto>>> ListItemsAsync(int cartId, CancellationToken stoppingToken = default)
    {
        var items = await itemRepository.ListItemsInCartAsync(cartId, stoppingToken);
        
        if (items is null)
            return Result<List<ItemDto>>.Failure(ErrorType.NotFound);

        var projections = items.Select(item => item.ToDto()).ToList();
        return Result<List<ItemDto>>.Success(projections);
    }
}