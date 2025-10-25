using Backend.Application.DTOs;
using Backend.Domain.Entities;
using Backend.Domain.ValueObjects;

namespace Backend.Application.Extensions;

public static class CpuExtensions
{
    public static CpuDto ToCpuDto(this Cpu cpu)
    {
        return new CpuDto
        {
            Id = cpu.Id,
            BrandName = cpu.Brand.BrandName,
            ModelName = cpu.ModelName,
            ImagePath = cpu.ImagePath,
            Price = new Price
            {
                Initial = cpu.InitialPrice,
                Discounted = cpu.Price
            },
            DiscountPercentage = cpu.DiscountPercentage,
            Cores = cpu.Cores,
            Threads = cpu.Threads,
            ClockSpeed = cpu.ClockSpeed,
            Socket = cpu.Socket,
            Tdp = cpu.Tdp,
            Rating = cpu.GetRating()
        };
    }
}