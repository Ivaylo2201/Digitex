using Backend.Application.DTOs.Product;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions;

public static class ProductBaseExtensions
{
    public static ProductShortDto ToProductDto(this ProductBase product) => new(product);

    public static int GetRating(this ProductBase product)
        => product.Reviews.Count > 0 ? (int)product.Reviews.Average(review => review.Rating) : 0;   
}