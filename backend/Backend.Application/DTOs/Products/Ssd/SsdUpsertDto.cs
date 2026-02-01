using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Application.DTOs.Products.Ssd;

public record SsdModifyDto
{
    public required int CapacityInGb { get; init; }
    public required OperationSpeed OperationSpeed { get; init; }
    public required StorageInterface StorageInterface { get; init; }
}