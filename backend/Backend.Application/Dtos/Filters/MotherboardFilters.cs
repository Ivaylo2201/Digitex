namespace Backend.Application.Dtos.Filters;

public record MotherboardFilters(
    IReadOnlyList<string> Brands,
    IReadOnlyList<string> Sockets,
    IReadOnlyList<string> FormFactors,
    IReadOnlyList<string> Chipsets
);