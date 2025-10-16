namespace Backend.Domain.Entities;

public class Country
{
    public int Id { get; init; }
    public required string CountryName { get; init; }
    public ICollection<City> Cities { get; init; } = [];  
}