using Backend.Domain.Enums;

namespace Backend.Domain.Entities;

public class Motherboard : ProductBase
{
    public required Socket Socket { get; init; }
    public required FormFactor FormFactor { get; init; }
    public required string Chipset { get; init; }
    public required int RamSlots { get; init; }
    public required int PcieSlots { get; init; }
}