using Backend.Domain.ValueObjects;

namespace Backend.Domain.Entities;

public class Address
{
    public int Id { get; init; }
    public int CityId { get; init; }
    public City City { get; init; } = null!;
    public int UserId { get; init; }
    public User User { get; init; } = null!;
    public required Street Street { get; init; }
    public int? Floor { get; init; }
    public int? ApartmentNumber { get; init; }
}