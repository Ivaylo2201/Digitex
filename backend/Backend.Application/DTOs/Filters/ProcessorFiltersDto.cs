namespace Backend.Application.DTOs.Filters;

public record ProcessorFiltersDto
{
    public required IEnumerable<string> Brands { get; init; }
    public required IEnumerable<int> Cores { get; init; }
    public required IEnumerable<int> Threads { get; init; }
    public required IEnumerable<string> Sockets { get; init; }
    public required int MinTdp { get; init; }
    public required int MaxTdp { get; init; }
}
