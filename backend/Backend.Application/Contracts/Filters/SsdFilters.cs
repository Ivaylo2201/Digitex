namespace Backend.Application.Contracts.Filters;

public record SsdFilters
{
    public required IReadOnlyList<string> Brands { get; init; }
    public required IReadOnlyList<int> MemoryCapacities { get; init; }
    public required IReadOnlyList<string> StorageInterfaces { get; init; }
    public required int MinReadSpeed { get; init; }
    public required int MaxReadSpeed { get; init; }
    public required int MinWriteSpeed { get; init; }
    public required int MaxWriteSpeed { get; init; }
}