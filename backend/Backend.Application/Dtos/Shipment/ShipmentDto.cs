using Backend.Domain.Enums;

namespace Backend.Application.Dtos.Shipment;

public record ShipmentDto
{
    public required int Id { get; set; }
    public required ShipmentType ShipmentType { get; init; }
    public required int Cost { get; init; }
    public required int Days { get; init; }
}