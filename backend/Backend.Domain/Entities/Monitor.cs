using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Domain.Entities;

public class Monitor : ProductBase
{
    public required int DisplayDiagonal { get; init; }
    public required int RefreshRate { get; init; }
    public required int Latency { get; init; }
    public required Matrix Matrix { get; init; }
    public required Resolution Resolution { get; init; }
    public required double PixelSize { get; init; }
}