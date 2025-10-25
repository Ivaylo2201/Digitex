using Backend.Application.DTOs.Product;
using Backend.Domain.ValueObjects;

namespace Backend.Application.DTOs.Ram;

public record RamDto : ProductDto
{
    public required Memory Memory { get; init; }
    public required string Timing { get; init; }
}