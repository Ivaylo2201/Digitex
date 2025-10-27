using Backend.Domain.Entities;
using Backend.Domain.ValueObjects;

namespace Backend.Application.DTOs.Product;

public class ProductShortDto(ProductBase product)
{
    public Guid Id { get; init; } = product.Id;
    public string BrandName { get; init; } = product.Brand.BrandName;
    public string ModelName { get; init; } = product.ModelName;
    public string ImagePath { get; init; } = product.ImagePath;
    public Price Price { get; init; } = new()
    {
        Initial = product.InitialPrice,
        Discounted = product.Price
    };
    public int DiscountPercentage { get; init; } = product.DiscountPercentage;
    public int Rating { get; init; } = product.Rating;
}