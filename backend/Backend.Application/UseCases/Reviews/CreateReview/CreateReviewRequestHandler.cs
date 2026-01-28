using System.Net;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace Backend.Application.UseCases.Reviews.CreateReview;

public class CreateReviewRequestHandler(IReviewRepository reviewRepository) : IRequestHandler<CreateReviewRequest, Result<ReviewDto>>
{
    public async Task<Result<ReviewDto>> Handle(CreateReviewRequest request, CancellationToken cancellationToken)
    {
        var review = await reviewRepository.CreateAsync(new Review
        {
            ProductId = request.ProductId,
            Rating = request.Rating,
            UserId = request.UserId,
            Comment = request.Comment
        }, cancellationToken);
        
        return Result<ReviewDto>.Success(HttpStatusCode.OK, review.Adapt<ReviewDto>());
    }
}