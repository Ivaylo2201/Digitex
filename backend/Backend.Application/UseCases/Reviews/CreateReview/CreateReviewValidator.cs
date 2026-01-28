using FluentValidation;

namespace Backend.Application.UseCases.Reviews.CreateReview;

public class CreateReviewValidator : AbstractValidator<CreateReviewRequest>
{
    public CreateReviewValidator()
    {
        
    }
}