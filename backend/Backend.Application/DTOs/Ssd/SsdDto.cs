using Backend.Application.DTOs.Product;
using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Application.DTOs.Ssd;

using Ssd = Backend.Domain.Entities.Ssd;

public class SsdDto(Ssd ssd) : ProductLongDto(ssd)
{
    public required int CapacityInGb { get; init; }
    public required OperationSpeed OperationSpeed { get; init; }
    public required StorageInterface Interface { get; init; }
}