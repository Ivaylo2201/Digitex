using Backend.Domain.ValueObjects;

namespace Backend.Application.DTOs.Products.GraphicsCard;

public record GraphicsCardUpsertDto : ProductUpsertDtoBase
{
    public required Memory Memory { get; init; }
    public required ClockSpeed ClockSpeed { get; init; }
    public required int BusWidth { get; init; }
    public required int CudaCores { get; init; }
    public required int DirectXSupport { get; init; }
    public required int Tdp { get; init; }
}