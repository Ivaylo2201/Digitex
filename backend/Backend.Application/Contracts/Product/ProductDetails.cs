namespace Backend.Application.Contracts.Product;

public record ProductDetails : ProductSummary
{
    public required string Sku { get; init; }
    public required int TotalReviews { get; init; } 
}