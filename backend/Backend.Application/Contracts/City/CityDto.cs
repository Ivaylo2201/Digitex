namespace Backend.Application.Contracts.City;

public record CityDto
{
    public required string Id { get; init; }
    public required string CityName { get; init; }
}