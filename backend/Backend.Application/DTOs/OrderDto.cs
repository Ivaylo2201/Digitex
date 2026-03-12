using Backend.Domain.Enums;

namespace Backend.Application.DTOs;

public record OrderDto
{
    public IEnumerable<ItemDto> Items { get; init; } = [];
    public required string BillingAddress { get; init; }
    public required decimal TotalPrice { get; init; }
    public required ShipmentType ShipmentType { get; init; }
}