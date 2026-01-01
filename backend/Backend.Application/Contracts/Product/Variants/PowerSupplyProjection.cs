using Backend.Application.Contracts.Product.Base;
using Backend.Domain.Enums;

namespace Backend.Application.Contracts.Product.Variants;

public record PowerSupplyProjection : ProductDetails
{
    public required int Wattage { get; init; }
    public required FormFactor FormFactor { get; init; }
    public required int EfficiencyPercentage { get; init; }
    public required Modularity Modularity { get; init; }
}