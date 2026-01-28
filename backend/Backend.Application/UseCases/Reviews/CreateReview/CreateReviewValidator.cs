using FluentValidation;

namespace Backend.Application.UseCases.Reviews.CreateReview;

public class CreateReviewValidator : AbstractValidator<CreateReviewRequest>
{
    public CreateReviewValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("ProductId is required")
            .WithMessage("Invalid ProductId");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5)
            .WithMessage("Rating must be between 1 and 5");

        RuleFor(x => x.Comment)
            .MaximumLength(500)
            .WithMessage("Comment cannot exceed 500 characters");
    }
}