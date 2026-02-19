using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces.Repositories;

public interface ISaleRepository
{
    Task<decimal> GetTotalRevenueAsync(CancellationToken cancellationToken);
    Task<List<IGrouping<int, Sale>>> GetSalesForYearAsync(int year, CancellationToken cancellationToken);
}