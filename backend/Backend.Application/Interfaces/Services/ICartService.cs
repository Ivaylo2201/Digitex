using Backend.Application.Dtos.Cart;
using Backend.Application.Dtos.Item;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Services;

public interface ICartService
{
    Task<Result> AddToCartAsync(AddToCartDto cartDto, CancellationToken stoppingToken = default);
    
    Task<Result<List<ItemDto>>> ListItemsInCartAsync(ListItemsInCartDto cartDto, CancellationToken stoppingToken = default);
    Task<Result> RemoveFromCartAsync(RemoveFromCartDto cartDto, CancellationToken stoppingToken = default);
}