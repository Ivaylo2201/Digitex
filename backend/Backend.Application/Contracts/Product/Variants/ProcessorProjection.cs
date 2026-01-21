using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Application.Contracts.Product.Variants;

public record ProcessorProjection : ProductDetailsDto
{
    public required int Cores { get; init; }
    public required int Threads { get; init; }
    public required ClockSpeed ClockSpeed { get; init; }
    public required Socket Socket { get; init; } 
    public required int Tdp { get; init; }
}