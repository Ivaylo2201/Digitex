using Backend.Application.DTOs.Product;
using Backend.Domain.Enums;

namespace Backend.Application.DTOs.PowerSupply;

using PowerSupply = Backend.Domain.Entities.PowerSupply;

public class PowerSupplyDto(PowerSupply powerSupply) : ProductLongDto(powerSupply)
{
    public required int Wattage { get; init; }
    public required FormFactor FormFactor { get; init; }
    public required int EfficiencyPercentage { get; init; }
    public required Modularity Modularity { get; init; }
}