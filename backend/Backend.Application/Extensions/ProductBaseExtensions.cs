using Backend.Application.DTOs;
using Backend.Domain.Entities;
using Backend.Domain.ValueObjects;

namespace Backend.Application.Extensions;

public static class ProductBaseExtensions
{
    public static ProductDto ToProductDto(this ProductBase product)
    {
        return new ProductDto
        {
            Id = product.Id,
            BrandName = product.Brand.BrandName,
            ModelName = product.ModelName,
            ImagePath = product.ImagePath,
            Price = new Price
            {
                Initial = Math.Round(product.InitialPrice, 2),
                Discounted = Math.Round(product.Price, 2)
            },
            DiscountPercentage = product.DiscountPercentage,
            Rating = product.GetRating()
        };
    }

    public static int GetRating(this ProductBase product)
    {
        return product.Reviews.Count > 0 ? (int)product.Reviews.Average(review => review.Rating) : 0;   
    }
}