namespace Backend.Application.Filters.Common;

public record FiltersBase
{
    public required List<string> BrandNames { get; init; }
    public Range<double> Price { get; init; } = new(1.0, 1000.0);
}