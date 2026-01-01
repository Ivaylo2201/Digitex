namespace Backend.Application.Contracts.Product.Base;

public record ProductDetails : ProductSummary
{
    public required string Sku { get; init; }
    public required int TotalReviews { get; init; } 
}