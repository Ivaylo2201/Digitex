namespace Backend.Application.Dtos.Filters;

public record RamFilters(
    IReadOnlyList<string> Brands,
    IReadOnlyList<int> MemoryCapacities,
    IReadOnlyList<string> MemoryTypes,
    IReadOnlyList<int> Frequencies
);