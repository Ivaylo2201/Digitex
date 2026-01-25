using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Application.DTOs.Products;

public record GraphicsCardDto : ProductDetailsDto
{
    public required Memory Memory { get; init; }
    public required ClockSpeed ClockSpeed { get; init; }
    public required BusWidth BusWidth { get; init; }
    public required int CudaCores { get; init; }
    public required int DirectXSupport { get; init; }
    public required int Tdp { get; init; }
}
