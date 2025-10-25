using Backend.Domain.ValueObjects;

namespace Backend.Application.DTOs;

public record RamDto : ProductDto
{
    public required Memory Memory { get; init; }
    public required string Timing { get; init; }
}