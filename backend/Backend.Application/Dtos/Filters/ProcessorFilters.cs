namespace Backend.Application.Dtos.Filters;

public record ProcessorFilters
{
    public required IReadOnlyList<string> Brands { get; init; }
    public required IReadOnlyList<int> Cores { get; init; }
    public required IReadOnlyList<int> Threads { get; init; }
    public required IReadOnlyList<string> Sockets { get; init; }
    public required int MinTdp { get; init; }
    public required int MaxTdp { get; init; }
}
