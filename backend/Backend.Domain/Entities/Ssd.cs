using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Domain.Entities;

public class Ssd : ProductBase
{
    public required int CapacityInGb { get; init; }
    public required OperationSpeed OperationSpeed { get; init; }
    public required StorageInterface StorageInterface { get; init; }
}