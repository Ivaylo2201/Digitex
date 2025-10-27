using Backend.Application.DTOs.Ram;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions;

public static class RamExtensions
{
    public static RamDto ToRamDto(this Ram ram) => new(ram)
    {
        Memory = ram.Memory,
        Timing = ram.Timing,
    };
}