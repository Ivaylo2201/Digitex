namespace Backend.Application.DTOs.Filters;

public record SsdFiltersDto
{
    public required IEnumerable<string> Brands { get; init; }
    public required IEnumerable<int> MemoryCapacities { get; init; }
    public required IEnumerable<string> StorageInterfaces { get; init; }
    public required int MinReadSpeed { get; init; }
    public required int MaxReadSpeed { get; init; }
    public required int MinWriteSpeed { get; init; }
    public required int MaxWriteSpeed { get; init; }
}