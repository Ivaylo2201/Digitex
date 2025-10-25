using Backend.Application.DTOs;
using Backend.Domain.Entities;
using Backend.Domain.ValueObjects;

namespace Backend.Application.Extensions;

public static class GpuExtensions
{
    public static GpuDto ToGpuDto(this Gpu gpu)
    {
        return new GpuDto
        {
            Id = gpu.Id,
            BrandName = gpu.Brand.BrandName,
            ModelName = gpu.ModelName,
            ImagePath = gpu.ImagePath,
            Price = new Price
            {
                Initial = gpu.InitialPrice,
                Discounted = gpu.Price
            },
            DiscountPercentage = gpu.DiscountPercentage,
            Memory = gpu.Memory,
            ClockSpeed = gpu.ClockSpeed,
            BusWidth = gpu.BusWidth,
            CudaCores = gpu.CudaCores,
            DirectXSupport = gpu.DirectXSupport,
            Tdp = gpu.Tdp,
            Rating = gpu.GetRating()
        };
    }
}