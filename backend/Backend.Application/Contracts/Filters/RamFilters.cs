namespace Backend.Application.Contracts.Filters;

public record RamFilters
{
    public required IReadOnlyList<string> Brands { get; init; }
    public required IReadOnlyList<int> MemoryCapacities { get; init; }
    public required IReadOnlyList<string> MemoryTypes { get; init; }
    public required IReadOnlyList<int> Frequencies { get; init; }
}