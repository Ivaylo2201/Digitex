using Backend.Application.DTOs.Product;
using Backend.Domain.Enums;

namespace Backend.Application.DTOs.Motherboard;

using Motherboard = Backend.Domain.Entities.Motherboard;

public class MotherboardDto(Motherboard motherboard) : ProductLongDto(motherboard)
{
    public required Socket Socket { get; init; }
    public required FormFactor FormFactor { get; init; }
    public required Chipset Chipset { get; init; }
    public required int RamSlots { get; init; }
    public required int PcieSlots { get; init; }
}