using Backend.Application.Filters.Common;

namespace Backend.Application.Filters;

public record CpuFilters : FiltersBase
{
    public required List<int> Cores { get; init; }
    public required List<int> Threads { get; init; }
    public required List<string> Socket { get; init; }
    public required Range<int> Tdp { get; init; }
    public required Range<double> BaseClockSpeed { get; init; }
    public required Range<double> BoostClockSpeed { get; init; }
}