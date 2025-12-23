namespace Backend.Application.Dtos.Filters;

public record MotherboardFilters
{
    public required IReadOnlyList<string> Brands { get; init; }
    public required IReadOnlyList<string> Sockets { get; init; }
    public required IReadOnlyList<string> FormFactors { get; init; }
    public required IReadOnlyList<string> Chipsets { get; init; }
}