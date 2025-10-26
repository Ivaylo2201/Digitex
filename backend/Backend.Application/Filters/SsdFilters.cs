using Backend.Application.Filters.Common;

namespace Backend.Application.Filters;

public record SsdFilters : FiltersBase
{
    public required Range<int> CapacityInGb { get; init; }
    public required List<string> StorageInterfaces { get; init; }
    public required Range<int> ReadSpeed { get; init; }
    public required Range<int> WriteSpeed { get; init; }
}