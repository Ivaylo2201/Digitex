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
                Initial = product.InitialPrice,
                Discounted = product.Price
            },
            DiscountPercentage = product.DiscountPercentage,
        };
    }
}