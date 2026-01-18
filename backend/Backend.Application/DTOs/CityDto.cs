namespace Backend.Application.DTOs;

public record CityDto
{
    public required string Id { get; init; }
    public required string CityName { get; init; }
}