using Backend.Domain.Common;

namespace Backend.Domain.Interfaces;

public interface IProductBaseRepository
{
    Task<Result> UpdateRatingAsync(Guid id, int newRating, CancellationToken stoppingToken = default);
}