using Backend.Application.Dtos.Review;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Services;

public interface IReviewService
{
    Task<Result<ReviewDto>> AddReviewAsync(AddReviewDto reviewDto, CancellationToken stoppingToken = default);
}