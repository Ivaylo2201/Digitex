using Backend.Application.Dtos.Review;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class ReviewService(ILogger<ReviewService> logger, IReviewRepository reviewRepository) : IReviewService
{
    private const string Source = nameof(ReviewService);
    
    public async Task<Result<ReviewDto>> AddReviewAsync(AddReviewDto reviewDto, CancellationToken stoppingToken = default)
    {
        var review = await reviewRepository.CreateAsync(new Review
        {
            Comment = reviewDto.Comment,
            UserId = reviewDto.UserId,
            Rating = reviewDto.Rating,
            ProductId = reviewDto.ProductId
        }, stoppingToken);
        
        logger.LogInformation("[{Source}]: Projecting review into a ReviewDto...", Source);
        return Result<ReviewDto>.Success(review.Adapt<ReviewDto>());
    }
}