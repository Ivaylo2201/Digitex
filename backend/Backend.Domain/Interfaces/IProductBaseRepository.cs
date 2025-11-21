using Backend.Domain.Common;

namespace Backend.Domain.Interfaces;

public interface IProductBaseRepository
{
    Task UpdateRatingAsync(Guid id, int newRating, CancellationToken stoppingToken = default);
    Task DecreaseQuantityAsync(Guid id, CancellationToken stoppingToken = default);
    Task<bool> IsInStockAsync(Guid id, CancellationToken stoppingToken = default);
    Task<bool> AddSuggestionAsync(Guid productId, Guid suggestedProductId, CancellationToken stoppingToken = default);
}