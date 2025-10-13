using Backend.Domain.ValueObjects;

namespace Backend.Domain.Entities;

public class Ram : ProductBase
{
    public required Memory Memory { get; init; }
    public required string Timing { get; init; }
}