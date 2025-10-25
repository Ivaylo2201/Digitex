using Backend.Application.DTOs;
using Backend.Domain.Entities;
using Backend.Domain.ValueObjects;

namespace Backend.Application.Extensions;

public static class CpuExtensions
{
    public static CpuDto ToCpuDto(this Cpu entity)
    {
        return new CpuDto
        {
            Id = entity.Id,
            BrandName = entity.Brand.BrandName,
            ModelName = entity.ModelName,
            ImagePath = entity.ImagePath,
            Price = new Price
            {
                Initial = entity.InitialPrice,
                Discounted = entity.Price
            },
            DiscountPercentage = entity.DiscountPercentage,
            Cores = entity.Cores,
            Threads = entity.Threads,
            ClockSpeed = entity.ClockSpeed,
            Socket = entity.Socket,
            Tdp = entity.Tdp
        };
    }
}