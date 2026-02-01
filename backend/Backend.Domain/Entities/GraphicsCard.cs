using Backend.Domain.ValueObjects;

namespace Backend.Domain.Entities;

public class GraphicsCard : ProductBase
{
    public required Memory Memory { get; init; }
    public required ClockSpeed ClockSpeed { get; init; }
    public required int BusWidth { get; init; }
    public required int CudaCores { get; init; }
    public required int DirectXSupport { get; init; }
    public required int Tdp { get; init; }
}