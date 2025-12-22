namespace Backend.Application.Dtos.Filters;

public record GraphicsCardFilters(
    IReadOnlyList<string> Brands,
    IReadOnlyList<int> BusWidths,
    IReadOnlyList<int> MemoryCapacities,
    int MinClockSpeed,
    int MaxClockSpeed,
    IReadOnlyList<int> CudaCores
);