namespace Backend.Application.UseCases.Manager.GetCategorySales;

public record CategorySaleReport
{
    public required string Category { get; init; }
    public required int Percentage { get; init; }
    public required int Count { get; init; }
}