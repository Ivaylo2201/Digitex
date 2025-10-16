namespace Backend.Domain.Entities;

public class City
{
    public int Id { get; init; }
    public required string CityName { get; init; }
    public int CountryId { get; init; }   
    public Country Country { get; init; } = null!;
    public ICollection<Address> Addresses { get; init; } = [];   
}