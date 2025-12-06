using Backend.Domain.Enums;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Entities;

public class Shipment
{
    public int Id { get; set; }
    public required ShipmentType ShipmentType { get; init; }
    public required int Cost { get; init; }
    public required int Days { get; init; }
    public ICollection<Order> Orders { get; init; } = [];   
}