using System.Net;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Reviews.GetAllReviewsByProductId;

public class GetAllReviewsByProductIdRequestHandler(
    ILogger<GetAllReviewsByProductIdRequestHandler> logger,
    IReviewRepository reviewRepository) : IRequestHandler<GetAllReviewsByProductIdRequest, Result<IEnumerable<ReviewDto>>>
{
    private const string Source = nameof(GetAllReviewsByProductIdRequestHandler);
    
    public async Task<Result<IEnumerable<ReviewDto>>> Handle(GetAllReviewsByProductIdRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{Source}]: Getting recent reviews for Product {ProductId}...", Source, request.ProductId);
        var reviews = await reviewRepository.GetRecentByProductIdAsync(request.ProductId, request.Limit, cancellationToken);
        return Result<IEnumerable<ReviewDto>>.Success(HttpStatusCode.OK, reviews.Adapt<IEnumerable<ReviewDto>>());
    }
}