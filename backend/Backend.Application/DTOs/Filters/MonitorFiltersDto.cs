namespace Backend.Application.DTOs.Filters;

public record MonitorFiltersDto
{
    public required IEnumerable<string> Brands { get; init; }
    public required IEnumerable<int> RefreshRates { get; init; }
    public required IEnumerable<string> Matrices { get; init; }
    public required IEnumerable<string> ResolutionTypes { get; init; }
}