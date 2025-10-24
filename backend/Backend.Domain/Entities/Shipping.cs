using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Generics;

namespace Backend.Domain.Entities;

public class Shipping : IEntity<int>
{
    public int Id { get; set; }
    public required ShippingType ShippingType { get; init; }
    public required int Cost { get; init; }
    public required int Days { get; init; }
    public ICollection<Order> Orders { get; init; } = [];   
}