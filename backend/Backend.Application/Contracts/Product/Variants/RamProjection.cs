using Backend.Domain.ValueObjects;

namespace Backend.Application.Contracts.Product.Variants;

public record RamProjection : ProductDetailsDto
{
    public required Memory Memory { get; init; }
    public required string Timing { get; init; }
}