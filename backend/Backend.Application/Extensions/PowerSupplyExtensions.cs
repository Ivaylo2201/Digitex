using Backend.Application.DTOs.PowerSupply;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions;

public static class PowerSupplyExtensions
{
    public static PowerSupplyDto ToPowerSupplyDto(this PowerSupply powerSupply) => new(powerSupply)
    {
        Wattage = powerSupply.Wattage,
        FormFactor = powerSupply.FormFactor,
        EfficiencyPercentage = powerSupply.EfficiencyPercentage,
        Modularity = powerSupply.Modularity
    };
}