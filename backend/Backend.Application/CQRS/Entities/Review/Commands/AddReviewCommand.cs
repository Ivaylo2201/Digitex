using Backend.Application.DTOs.Review;
using Backend.Domain.Common;
using SimpleSoft.Mediator;

namespace Backend.Application.CQRS.Entities.Review.Commands;

public class AddReviewCommand(AddReviewDto dto) : Command<Result<ReviewDto>>
{
    public AddReviewDto Dto { get; } = dto;
}