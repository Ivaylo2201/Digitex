using Backend.Domain.ValueObjects;

namespace Backend.Application.DTOs.Products.Ram;

public record RamModifyDto : ProductModifyDtoBase
{
    public required Memory Memory { get; init; }
    public required string Timing { get; init; }
}