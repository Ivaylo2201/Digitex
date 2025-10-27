using Backend.Application.DTOs.Product;
using Backend.Domain.ValueObjects;

namespace Backend.Application.DTOs.Ram;

using Ram = Backend.Domain.Entities.Ram;

public class RamDto(Ram ram) : ProductLongDto(ram)
{
    public required Memory Memory { get; init; }
    public required string Timing { get; init; }
}