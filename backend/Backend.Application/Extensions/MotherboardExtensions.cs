using Backend.Application.DTOs.Motherboard;
using Backend.Domain.Entities;
using Backend.Domain.ValueObjects;

namespace Backend.Application.Extensions;

public static class MotherboardExtensions
{
    public static MotherboardDto ToMotherboardDto(this Motherboard motherboard)
    {
        return new MotherboardDto
        {
            Id = motherboard.Id,
            BrandName = motherboard.Brand.BrandName,
            ModelName = motherboard.ModelName,
            ImagePath = motherboard.ImagePath,
            Price = new Price
            {
                Initial = motherboard.InitialPrice,
                Discounted = motherboard.Price
            },
            DiscountPercentage = motherboard.DiscountPercentage,
            Socket = motherboard.Socket,
            FormFactor = motherboard.FormFactor,
            Chipset = motherboard.Chipset,
            RamSlots = motherboard.RamSlots,
            PcieSlots = motherboard.PcieSlots,
            Rating = motherboard.GetRating()
        };
    }
}