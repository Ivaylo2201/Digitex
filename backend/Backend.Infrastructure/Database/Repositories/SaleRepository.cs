using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class SaleRepository(DatabaseContext context) : ISaleRepository
{
    public async Task<decimal> GetTotalRevenueAsync(CancellationToken cancellationToken)
    {
        return await context.Sales
            .Include(sale => sale.Product)
            .SumAsync(sale => sale.QuantitySold * sale.Product.Price, cancellationToken);
    }

    public async Task<List<IGrouping<int, Sale>>> GetSalesForYearAsync(int year, CancellationToken cancellationToken)
    {
        return await context.Sales
            .Where(sale => sale.SaleDate.Year == year)
            .GroupBy(s => s.SaleDate.Month)
            .ToListAsync(cancellationToken);
    }
}