using Backend.Application.Dtos.Product;
using Backend.Domain.ValueObjects;

namespace Backend.Application.Dtos.Products;

public record RamDto : ProductLongDto
{
    public required Memory Memory { get; init; }
    public required string Timing { get; init; }
}