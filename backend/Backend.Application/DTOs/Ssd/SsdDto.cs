using Backend.Application.DTOs.Product;
using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Application.DTOs.Ssd;

public record SsdDto : ProductDto
{
    public required int CapacityInGb { get; init; }
    public required OperationSpeed OperationSpeed { get; init; }
    public required StorageInterface Interface { get; init; }
}