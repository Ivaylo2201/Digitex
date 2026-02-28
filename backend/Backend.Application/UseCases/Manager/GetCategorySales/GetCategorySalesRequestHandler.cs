using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;

namespace Backend.Application.UseCases.Manager.GetCategorySales;

public class GetCategorySalesRequestHandler(ISaleRepository saleRepository) : IRequestHandler<GetCategorySalesRequest, Result<List<CategorySaleReport>>>
{
    public async Task<Result<List<CategorySaleReport>>> Handle(GetCategorySalesRequest request, CancellationToken cancellationToken)
    {
        var sales = await saleRepository.GetSalesWithProductAsync(cancellationToken);
        var groups = sales.GroupBy(x => x.Product.Category);

        var categorySaleReports = groups.Select(group => new CategorySaleReport
        {
            Category = group.Key,
            Percentage = sales.Count == 0
                ? 0
                : (int)Math.Round((double)group.Count() / sales.Count * 100),
            Count = group.Count()
        }).ToList();
        
        return Result<List<CategorySaleReport>>.Success(HttpStatusCode.OK, categorySaleReports);
    }
}