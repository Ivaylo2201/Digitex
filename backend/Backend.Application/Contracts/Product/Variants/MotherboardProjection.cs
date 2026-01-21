using Backend.Domain.Enums;

namespace Backend.Application.Contracts.Product.Variants;

public record MotherboardProjection : ProductDetailsDto
{
    public required Socket Socket { get; init; }
    public required FormFactor FormFactor { get; init; }
    public required Chipset Chipset { get; init; }
    public required int RamSlots { get; init; }
    public required int PcieSlots { get; init; }
}