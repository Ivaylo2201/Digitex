using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;

namespace Backend.Infrastructure.Services.Entities;

public class ProductBaseService(IProductBaseRepository productBaseRepository, IReviewRepository reviewRepository) : IProductBaseService
{
    public async Task<Result> UpdateRatingAsync(Guid id, CancellationToken stoppingToken = default)
    {
        var averageRating = await reviewRepository.GetAverageRatingAsync(id);
        await productBaseRepository.UpdateRatingAsync(id, (int)Math.Round(averageRating, 0), stoppingToken);
        return Result.Success();
    }
}