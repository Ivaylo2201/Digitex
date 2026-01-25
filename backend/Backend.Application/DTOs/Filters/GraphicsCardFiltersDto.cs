namespace Backend.Application.DTOs.Filters;

public record GraphicsCardFiltersDto
{
    public required IEnumerable<string> Brands { get; init; }
    public required IEnumerable<int> BusWidths { get; init; }
    public required IEnumerable<int> MemoryCapacities { get; init; }
    public required int MinClockSpeed { get; init; }
    public required int MaxClockSpeed { get; init; }
    public required IEnumerable<int> CudaCores { get; init; }
}
