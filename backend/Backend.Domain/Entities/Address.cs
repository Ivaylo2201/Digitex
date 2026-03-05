namespace Backend.Domain.Entities;

public class Address
{
    public int Id { get; init; }
    public int CityId { get; init; }
    public City City { get; init; } = null!;
    public int UserId { get; init; }
    public User User { get; init; } = null!;
    public required string StreetName { get; init; }
    public required int StreetNumber { get; init; }
    public int? Floor { get; init; }
    public int? ApartmentNumber { get; init; }
    
    public ICollection<Order> Orders { get; init; } = [];
}