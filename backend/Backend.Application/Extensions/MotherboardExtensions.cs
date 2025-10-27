using Backend.Application.DTOs.Motherboard;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions;

public static class MotherboardExtensions
{
    public static MotherboardDto ToMotherboardDto(this Motherboard motherboard) => new(motherboard)
    {
        Socket = motherboard.Socket,
        FormFactor = motherboard.FormFactor,
        Chipset = motherboard.Chipset,
        RamSlots = motherboard.RamSlots,
        PcieSlots = motherboard.PcieSlots
    };
}