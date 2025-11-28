using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services.Entities;

// TODO: Refactor
public class ItemService(IItemRepository itemRepository) : IItemService
{
    public async Task<Result> IsItemOwnedByUserAsync(int itemId, int userId, CancellationToken stoppingToken = default)
    {
        var isItemOwnedByUser = await itemRepository.IsItemOwnedByUserAsync(itemId, userId, stoppingToken);
        
        if (!isItemOwnedByUser)
            return Result.Failure(StatusCodes.Status403Forbidden);
        
        return Result.Success(StatusCodes.Status200OK);       
    }
}