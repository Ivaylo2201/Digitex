namespace Backend.Application.Dtos.Filters;

public record SsdFilters(
    IReadOnlyList<string> Brands,
    IReadOnlyList<int> MemoryCapacities,
    IReadOnlyList<string> StorageInterfaces,
    int MinReadSpeed,
    int MaxReadSpeed,
    int MinWriteSpeed,
    int MaxWriteSpeed
);