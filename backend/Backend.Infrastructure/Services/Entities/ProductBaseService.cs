using Backend.Application.Dtos.Admin;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services.Entities;

public class ProductBaseService(IProductBaseRepository productBaseRepository, IReviewRepository reviewRepository) : IProductBaseService
{
    public async Task<Result> UpdateRatingAsync(Guid id, CancellationToken stoppingToken = default)
    {
        var averageRating = await reviewRepository.GetAverageRatingAsync(id);
        await productBaseRepository.UpdateRatingAsync(id, (int)Math.Round(averageRating, 0), stoppingToken);
        return Result.Success(StatusCodes.Status200OK);
    }

    public async Task<Result> AddSuggestionAsync(AddSuggestionDto dto, CancellationToken stoppingToken = default)
    {
        var result = await productBaseRepository.AddSuggestionAsync(dto.ProductId, dto.SuggestedProductId, stoppingToken);
        return result ? Result.Success(StatusCodes.Status200OK) : Result.Failure(StatusCodes.Status404NotFound);
    }
}