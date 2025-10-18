using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Domain.Entities;

public class Monitor : ProductBase
{
    public required double DisplayDiagonal { get; init; }
    public required RefreshRate RefreshRate { get; init; }
    public required double Latency { get; init; }
    public required Matrix Matrix { get; init; }
    public required Resolution Resolution { get; init; }
    public required double PixelSize { get; init; }
    public required int Brightness { get; init; }
    public required int ColorSpectre { get; init; }
}