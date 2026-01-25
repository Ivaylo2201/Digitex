namespace Backend.Application.DTOs.Filters;

public record RamFiltersDto
{
    public required IEnumerable<string> Brands { get; init; }
    public required IEnumerable<int> MemoryCapacities { get; init; }
    public required IEnumerable<string> MemoryTypes { get; init; }
    public required IEnumerable<int> Frequencies { get; init; }
}