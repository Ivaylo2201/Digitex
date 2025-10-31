using Backend.Application.DTOs.Cart;
using Backend.Application.DTOs.Item;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Services;

public interface ICartService
{
    Task<Result> AddToCartAsync(AddToCartDto cartDto, CancellationToken stoppingToken = default);
    
    Task<Result<List<ItemDto>>> ListItemsAsync(int cartId, CancellationToken stoppingToken = default);
}