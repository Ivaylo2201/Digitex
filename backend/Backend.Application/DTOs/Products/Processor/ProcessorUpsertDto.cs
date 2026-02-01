using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Application.DTOs.Products.Processor;

public record ProcessorUpsertDto : ProductUpsertDtoBase
{
    public required int Cores { get; init; }
    public required int Threads { get; init; }
    public required ClockSpeed ClockSpeed { get; init; }
    public required Socket Socket { get; init; } 
    public required int Tdp { get; init; }
}