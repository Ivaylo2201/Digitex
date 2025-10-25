using Backend.Application.DTOs;
using Backend.Domain.Entities;
using Backend.Domain.ValueObjects;

namespace Backend.Application.Extensions;

public static class PowerSupplyExtensions
{
    public static PowerSupplyDto ToPowerSupplyDto(this PowerSupply powerSupply)
    {
        return new PowerSupplyDto
        {
            Id = powerSupply.Id,
            BrandName = powerSupply.Brand.BrandName,
            ModelName = powerSupply.ModelName,
            ImagePath = powerSupply.ImagePath,
            Price = new Price
            {
                Initial = Math.Round(powerSupply.InitialPrice, 2),
                Discounted = Math.Round(powerSupply.Price, 2)
            },
            DiscountPercentage = powerSupply.DiscountPercentage,
            Wattage = powerSupply.Wattage,
            FormFactor = powerSupply.FormFactor,
            EfficiencyPercentage = powerSupply.EfficiencyPercentage,
            Modularity = powerSupply.Modularity,
            Rating = powerSupply.GetRating()
        };
    }
}