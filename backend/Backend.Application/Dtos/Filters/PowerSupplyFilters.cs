namespace Backend.Application.Dtos.Filters;

public record PowerSupplyFilters(
    IReadOnlyList<string> Brands,
    IReadOnlyList<string> FormFactors,
    IReadOnlyList<string> Modularities,
    int MinEfficiencyPercentage,
    int MaxEfficiencyPercentage
);