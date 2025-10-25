using Backend.Application.DTOs;
using Backend.Domain.ValueObjects;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Application.Extensions;

public static class MonitorExtensions
{
    public static MonitorDto ToMonitorDto(this Monitor monitor)
    {
        return new MonitorDto
        {
            Id = monitor.Id,
            BrandName = monitor.Brand.BrandName,
            ModelName = monitor.ModelName,
            ImagePath = monitor.ImagePath,
            Price = new Price
            {
                Initial = monitor.InitialPrice,
                Discounted = monitor.Price
            },
            DiscountPercentage = monitor.DiscountPercentage,
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
}