namespace Backend.Application.DTOs.Products;

public record ProductModifyDtoBase
{
    public required int BrandId { get; init; }
    public required string ModelName { get; init; }
    public required string ImagePath { get; init; }
    public required decimal InitialPrice { get; set; }
    public int DiscountPercentage { get; init; }
    public required int Quantity { get; set; }
}