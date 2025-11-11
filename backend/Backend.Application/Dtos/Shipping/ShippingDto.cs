using Backend.Domain.Enums;

namespace Backend.Application.Dtos.Shipping;

public record ShippingDto
{
    public required int Id { get; set; }
    public required ShippingType ShippingType { get; init; }
    public required int Cost { get; init; }
    public required int Days { get; init; }
}