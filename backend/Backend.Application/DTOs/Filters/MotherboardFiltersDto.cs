namespace Backend.Application.DTOs.Filters;

public record MotherboardFiltersDto
{
    public required IEnumerable<string> Brands { get; init; }
    public required IEnumerable<string> Sockets { get; init; }
    public required IEnumerable<string> FormFactors { get; init; }
    public required IEnumerable<string> Chipsets { get; init; }
}