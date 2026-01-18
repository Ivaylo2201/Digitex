namespace Backend.Application.DTOs;

public record ItemDto
{
    public required int Id { get; init; }
    public required ProductDto Product { get; init; }
    public required int Quantity { get; init; }
    public required decimal LineTotal { get; init; }
}

public record ProductDto
{
    public required string Sku { get; init; }
    public required int StockQuantity { get; init; }
    public required string BrandName { get; init; }
    public required string ModelName { get; init; }
    public required decimal Price { get; set; }   
    public required string ImagePath { get; init; }   
}