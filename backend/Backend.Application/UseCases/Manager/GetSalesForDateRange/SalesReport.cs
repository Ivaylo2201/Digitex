namespace Backend.Application.UseCases.Manager.GetSalesForDateRange;

public record SalesReport
{
    public required string Month { get; init; }
    public required int Sales { get; init; }
}