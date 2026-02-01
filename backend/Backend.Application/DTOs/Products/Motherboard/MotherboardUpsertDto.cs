using Backend.Domain.Enums;

namespace Backend.Application.DTOs.Products.Motherboard;

public record MotherboardUpsertDto : ProductUpsertDtoBase
{
    public required Socket Socket { get; init; }
    public required FormFactor FormFactor { get; init; }
    public required Chipset Chipset { get; init; }
    public required int RamSlots { get; init; }
    public required int PcieSlots { get; init; }
}