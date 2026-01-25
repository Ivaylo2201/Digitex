namespace Backend.Application.DTOs.Filters;

public record PowerSupplyFiltersDto
{
    public required IEnumerable<string> Brands { get; init; }
    public required IEnumerable<string> FormFactors { get; init; }
    public required IEnumerable<string> Modularities { get; init; }
    public required int MinEfficiencyPercentage { get; init; }
    public required int MaxEfficiencyPercentage { get; init; }
}