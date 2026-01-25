using Backend.Domain.Enums;

namespace Backend.Application.DTOs.Products;

public record PowerSupplyDto : ProductDetailsDto
{
    public required int Wattage { get; init; }
    public required FormFactor FormFactor { get; init; }
    public required int EfficiencyPercentage { get; init; }
    public required Modularity Modularity { get; init; }
}