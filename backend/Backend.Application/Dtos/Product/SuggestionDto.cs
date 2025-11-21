namespace Backend.Application.Dtos.Product;

public record SuggestionDto
{
    public required Guid Id { get; init; }
    public required string Category { get; init; }
    public required string BrandName { get; init; }
    public required string ModelName { get; init; }
    public required string ImagePath { get; init; }
}