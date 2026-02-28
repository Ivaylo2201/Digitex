using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories.Generics;

namespace Backend.Domain.Interfaces.Repositories;

public interface ISaleRepository : ICreatable<Sale>
{
    Task<decimal> GetTotalRevenueAsync(CancellationToken cancellationToken);
    Task<List<IGrouping<int, Sale>>> GetSalesForYearAsync(int year, CancellationToken cancellationToken);
    Task<List<Sale>> GetSalesWithProductAsync(CancellationToken cancellationToken);
}