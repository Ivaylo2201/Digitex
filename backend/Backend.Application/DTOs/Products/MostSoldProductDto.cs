namespace Backend.Application.DTOs.Products;

public record MostSoldProductDto
{
    public required string BrandName { get; init; }
    public required string ModelName { get; init; }
    public required decimal Price { get; init; }
    public required int Sales { get; init; }
    public required int Quantity { get; init; }
    public string? ImagePath  { get; init; }
}