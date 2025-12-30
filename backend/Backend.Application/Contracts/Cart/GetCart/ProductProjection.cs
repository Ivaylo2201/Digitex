namespace Backend.Application.Contracts.Cart.GetCart;

public record ProductProjection
{
    public required string Sku { get; init; }
    public required string BrandName { get; init; }
    public required string ModelName { get; init; }
    public required decimal Price { get; set; }   
    public required string ImagePath { get; init; }   
}