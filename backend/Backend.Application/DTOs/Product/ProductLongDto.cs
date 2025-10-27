using Backend.Application.DTOs.Review;
using Backend.Application.Extensions;
using Backend.Domain.Entities;

namespace Backend.Application.DTOs.Product;

public class ProductLongDto : ProductShortDto
{
    public List<ReviewDto> Reviews { get; init; }

    protected ProductLongDto(ProductBase product) : base(product)
    {
        Reviews = product.Reviews.Select(review => review.ToReviewDto()).ToList();
    }
}