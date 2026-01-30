using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Application.DTOs.Products.Monitor;

public record MonitorDto : ProductDetailsDto
{
    public required double DisplayDiagonal { get; init; }
    public required int RefreshRate { get; init; }
    public required double Latency { get; init; }
    public required Matrix Matrix { get; init; }
    public required Resolution Resolution { get; init; }
    public required double PixelSize { get; init; }
    public required int Brightness { get; init; }
    public required int ColorSpectre { get; init; }
}