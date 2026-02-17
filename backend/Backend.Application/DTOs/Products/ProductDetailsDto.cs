namespace Backend.Application.DTOs.Products;

public record ProductDetailsDto : ProductSummaryDto
{
    public required string Sku { get; init; }
    public required int TotalReviews { get; init; }
    public ICollection<SuggestedProductDto> Suggestions { get; init; } = [];
}