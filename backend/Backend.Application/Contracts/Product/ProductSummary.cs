using Backend.Domain.ValueObjects;

namespace Backend.Application.Contracts.Product;

public record ProductSummary
{
    public required Guid Id { get; init; }
    public required string BrandName { get; init; }
    public required string ModelName { get; init; }
    public required string ImagePath { get; init; }
    public required Price Price { get; init; }
    public required int DiscountPercentage { get; init; }
    public required int Rating { get; init; }
    public required int Quantity { get; init; }
}