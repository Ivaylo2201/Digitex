using Backend.Application.DTOs.Review;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class ReviewService(ILogger<ReviewService> logger, IReviewRepository reviewRepository) : IReviewService
{
    public async Task<Result<ReviewDto>> AddReviewAsync(AddReviewDto reviewDto, CancellationToken stoppingToken = default)
    {
        throw new NotImplementedException();
    }
}