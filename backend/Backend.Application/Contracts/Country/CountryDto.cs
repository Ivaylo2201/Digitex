namespace Backend.Application.Contracts.Country;

public record CountryDto
{
    public required int Id { get; init; }
    public required string CountryName { get; init; }
}