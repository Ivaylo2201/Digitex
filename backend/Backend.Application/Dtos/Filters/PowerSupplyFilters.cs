namespace Backend.Application.Dtos.Filters;

public record PowerSupplyFilters
{
    public required IReadOnlyList<string> Brands { get; init; }
    public required IReadOnlyList<string> FormFactors { get; init; }
    public required IReadOnlyList<string> Modularities { get; init; }
    public required int MinEfficiencyPercentage { get; init; }
    public required int MaxEfficiencyPercentage { get; init; }
}