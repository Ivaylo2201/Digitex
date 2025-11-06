namespace Backend.Application.DTOs.Product;

public record ProductItemDto
{
    public required string Sku { get; init; }
    public required string BrandName { get; init; }
    public required string ModelName { get; init; }
    public required double Price { get; init; }   
    public required string ImagePath { get; init; }   
}