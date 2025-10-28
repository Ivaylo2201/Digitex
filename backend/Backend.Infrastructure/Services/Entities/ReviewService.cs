using Backend.Application.DTOs.Review;
using Backend.Application.Extensions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
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
        var projection = review.ToReviewDto();

        return Result<ReviewDto>.Success(projection);
    }
}