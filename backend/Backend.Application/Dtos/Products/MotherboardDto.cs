using Backend.Application.Dtos.Product;
using Backend.Domain.Enums;

namespace Backend.Application.Dtos.Products;

public record MotherboardDto : ProductLongDto
{
    public required Socket Socket { get; init; }
    public required FormFactor FormFactor { get; init; }
    public required Chipset Chipset { get; init; }
    public required int RamSlots { get; init; }
    public required int PcieSlots { get; init; }
}