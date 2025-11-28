using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Interfaces;

public interface IProductBaseRepository : ISingleReadable<ProductBase, Guid>
{
    Task UpdateRatingAsync(Guid id, int newRating, CancellationToken stoppingToken = default);
    Task DecreaseQuantityAsync(Guid id, CancellationToken stoppingToken = default);
    Task<bool> AddSuggestionAsync(Guid productId, Guid suggestedProductId, CancellationToken stoppingToken = default);
}