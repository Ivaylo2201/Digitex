namespace Backend.Domain.Entities;

public class City
{
    public int Id { get; init; }
    public required string CityName { get; init; }
    public ICollection<Address> Addresses { get; init; } = [];   
}