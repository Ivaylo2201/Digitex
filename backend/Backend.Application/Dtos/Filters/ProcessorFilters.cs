namespace Backend.Application.Dtos.Filters;

public record ProcessorFilters(
    IReadOnlyList<string> Brands,
    IReadOnlyList<int> Cores,
    IReadOnlyList<int> Threads,
    IReadOnlyList<string> Sockets,
    int MinTdp,
    int MaxTdp
);