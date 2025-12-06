using Backend.Application.Dtos.Product;
using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;

namespace Backend.Application.Dtos.Products;

public record SsdDto : ProductLongDto
{
    public required int CapacityInGb { get; init; }
    public required OperationSpeed OperationSpeed { get; init; }
    public required StorageInterface Interface { get; init; }
}