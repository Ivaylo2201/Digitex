using Backend.Application.DTOs.Review;
using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Entities.Review.Queries;

public class ListReviewsQuery : Query<Result<List<ReviewDto>>>
{
    public required Guid ProductId { get; init; }
}