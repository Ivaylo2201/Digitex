namespace Backend.Application.Dtos.Filters;

public record MonitorFilters
{
    public required IReadOnlyList<string> Brands { get; init; }
    public required IReadOnlyList<int> RefreshRates { get; init; }
    public required IReadOnlyList<string> Matrices { get; init; }
    public required IReadOnlyList<string> ResolutionTypes { get; init; }
}