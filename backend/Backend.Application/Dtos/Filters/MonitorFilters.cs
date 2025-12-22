namespace Backend.Application.Dtos.Filters;

public record MonitorFilters(
    IReadOnlyList<string> Brands,
    IReadOnlyList<int> RefreshRates,
    IReadOnlyList<string> Matrices,
    IReadOnlyList<string> ResolutionTypes
);