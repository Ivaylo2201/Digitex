using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces;

namespace Backend.Infrastructure.Services.Entities;

public class ItemService(IItemRepository itemRepository) : IItemService
{
    public async Task<Result> IsItemOwnedByUserAsync(int itemId, int userId, CancellationToken stoppingToken = default)
    {
        var isItemOwnedByUser = await itemRepository.IsItemOwnedByUserAsync(itemId, userId, stoppingToken);
        
        if (!isItemOwnedByUser)
            return Result.Failure(ErrorType.Forbidden);
        
        return Result.Success();       
    }
}