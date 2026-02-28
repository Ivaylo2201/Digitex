using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class SaleRepository(DatabaseContext context) : ISaleRepository
{
    public async Task<decimal> GetTotalRevenueAsync(CancellationToken cancellationToken)
    {
        return await context.Sales
            .SumAsync(sale =>
                    sale.QuantitySold *
                    (sale.Product.InitialPrice *
                     (1 - sale.Product.DiscountPercentage / 100m)),
                cancellationToken);
    }

    public async Task<List<IGrouping<int, Sale>>> GetSalesForYearAsync(int year, CancellationToken cancellationToken)
    {
        return await context.Sales
            .Include(sale => sale.Product)
            .Where(sale => sale.SaleDate.Year == year)
            .GroupBy(s => s.SaleDate.Month)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Sale>> GetSalesWithProductAsync(CancellationToken cancellationToken)
    {
        return await context.Sales
            .Include(sale => sale.Product)
            .ToListAsync(cancellationToken);
    }

    public async Task<Sale> CreateAsync(Sale item, CancellationToken cancellationToken)
    {
        var sale = await context.Sales.AddAsync(item, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return sale.Entity;
    }
}