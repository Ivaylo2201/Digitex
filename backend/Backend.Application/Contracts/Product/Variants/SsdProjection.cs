using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Application.Contracts.Product.Variants;

public record SsdProjection : ProductDetailsDto
{
    public required int CapacityInGb { get; init; }
    public required OperationSpeed OperationSpeed { get; init; }
    public required StorageInterface Interface { get; init; }
}