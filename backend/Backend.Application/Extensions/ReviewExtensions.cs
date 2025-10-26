using Backend.Application.DTOs.Review;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions;

public static class ReviewExtensions
{
    public static ReviewDto ToReviewDto(this Review review)
    {
        return new ReviewDto
        {
            Rating = review.Rating,
            Comment = review.Comment,
            Username = review.User.Username,
            CreatedAt = review.CreatedAt
        };
    }
}