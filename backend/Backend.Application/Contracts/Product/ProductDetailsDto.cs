namespace Backend.Application.Contracts.Product;

public record ProductDetailsDto : ProductSummaryDto
{
    public required string Sku { get; init; }
    public required int TotalReviews { get; init; } 
}