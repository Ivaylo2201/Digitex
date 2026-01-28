using Backend.Application.DTOs;
using Backend.Application.Interfaces.Common;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Reviews.CreateReview;

public record CreateReviewRequest : IRequest<Result<ReviewDto>>, IAuthorized
{
    public required Guid ProductId { get; init; }
    public required int Rating { get; init; }
    public int UserId { get; set; }
    public required string Comment { get; init; }
}