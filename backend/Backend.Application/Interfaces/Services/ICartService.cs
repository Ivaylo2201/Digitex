using Backend.Application.DTOs.Item;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Services;

public interface ICartService
{
    Task<Result<List<ItemDto>>> ListItemsAsync(int cartId, CancellationToken stoppingToken = default);
}