namespace Backend.Application.UseCases.Manager.GetTotalRevenue;

public record GetTotalRevenueResponse
{
    public required decimal TotalRevenue { get; init; }
}