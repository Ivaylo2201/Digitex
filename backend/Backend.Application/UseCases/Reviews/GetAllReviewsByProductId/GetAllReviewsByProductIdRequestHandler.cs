using System.Net;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace Backend.Application.UseCases.Reviews.GetAllReviewsByProductId;

public class GetAllReviewsByProductIdRequestHandler(IReviewRepository reviewRepository) : IRequestHandler<GetAllReviewsByProductIdRequest, Result<IEnumerable<ReviewDto>>>
{
    public async Task<Result<IEnumerable<ReviewDto>>> Handle(GetAllReviewsByProductIdRequest request, CancellationToken cancellationToken)
    {
        var reviews = await reviewRepository.GetRecentByProductIdAsync(request.ProductId, request.Limit, cancellationToken);
        return Result<IEnumerable<ReviewDto>>.Success(HttpStatusCode.OK, reviews.Adapt<IEnumerable<ReviewDto>>());
    }
}