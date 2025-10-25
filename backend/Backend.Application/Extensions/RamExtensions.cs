using Backend.Application.DTOs.Ram;
using Backend.Domain.Entities;
using Backend.Domain.ValueObjects;

namespace Backend.Application.Extensions;

public static class RamExtensions
{
    public static RamDto ToRamDto(this Ram ram)
    {
        return new RamDto
        {
            Id = ram.Id,
            BrandName = ram.Brand.BrandName,
            ModelName = ram.ModelName,
            ImagePath = ram.ImagePath,
            Price = new Price
            {
                Initial = ram.InitialPrice,
                Discounted = ram.Price
            },
            DiscountPercentage = ram.DiscountPercentage,
            Memory = ram.Memory,
            Timing = ram.Timing,
            Rating = ram.GetRating()
        };
    }
}