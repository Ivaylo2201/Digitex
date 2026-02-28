namespace Backend.Application.UseCases.Manager.GetSalesForYear;

public record SalesReport
{
    public required string Month { get; init; }
    public required int Sales { get; init; }
    public required decimal Revenue { get; init; }
}