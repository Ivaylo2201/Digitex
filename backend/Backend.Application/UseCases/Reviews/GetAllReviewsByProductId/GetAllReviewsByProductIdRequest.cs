using Backend.Application.DTOs;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Reviews.GetAllReviewsByProductId;

public record GetAllReviewsByProductIdRequest : IRequest<Result<IEnumerable<ReviewDto>>>
{
    public required Guid ProductId { get; init; }
    public required int Limit { get; init; }
}