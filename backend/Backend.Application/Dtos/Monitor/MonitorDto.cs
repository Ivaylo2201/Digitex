using Backend.Application.Dtos.Product;
using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Application.Dtos.Monitor;

public record MonitorDto : ProductLongDto
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