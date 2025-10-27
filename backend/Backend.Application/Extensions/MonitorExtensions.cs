using Backend.Application.DTOs.Monitor;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Application.Extensions;

public static class MonitorExtensions
{
    public static MonitorDto ToMonitorDto(this Monitor monitor) => new(monitor)
    {
        DisplayDiagonal = monitor.DisplayDiagonal,
        RefreshRate = monitor.RefreshRate,
        Latency = monitor.Latency,
        Matrix = monitor.Matrix,
        Resolution = monitor.Resolution,
        PixelSize = monitor.PixelSize,
        Brightness = monitor.Brightness,
        ColorSpectre = monitor.ColorSpectre
    };
}