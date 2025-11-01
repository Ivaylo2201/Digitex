using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Services;

public interface IItemService
{
    Task<Result> IsItemOwnedByUserAsync(int itemId, int userId, CancellationToken stoppingToken = default);
}