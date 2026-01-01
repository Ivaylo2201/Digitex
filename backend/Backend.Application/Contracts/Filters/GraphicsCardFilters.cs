namespace Backend.Application.Contracts.Filters;

public record GraphicsCardFilters
{
    public required IReadOnlyList<string> Brands { get; init; }
    public required IReadOnlyList<int> BusWidths { get; init; }
    public required IReadOnlyList<int> MemoryCapacities { get; init; }
    public required int MinClockSpeed { get; init; }
    public required int MaxClockSpeed { get; init; }
    public required IReadOnlyList<int> CudaCores { get; init; }
}
