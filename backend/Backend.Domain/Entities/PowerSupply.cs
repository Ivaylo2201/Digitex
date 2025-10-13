using Backend.Domain.Enums;

namespace Backend.Domain.Entities;

public class PowerSupply : ProductBase
{
    public required double Power { get; init; }
    public required FormFactor FormFactor { get; init; }
    public required int EfficiencyPercentage { get; init; }
}