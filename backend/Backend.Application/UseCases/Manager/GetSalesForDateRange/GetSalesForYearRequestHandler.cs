using System.Globalization;
using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;

namespace Backend.Application.UseCases.Manager.GetSalesForDateRange;

public class GetSalesForYearRequestHandler(ISaleRepository saleRepository) 
    : IRequestHandler<GetSalesForYearRequest, Result<List<SalesReport>>>
{
    public async Task<Result<List<SalesReport>>> Handle(GetSalesForYearRequest request, CancellationToken cancellationToken)
    {
        var groups = await saleRepository.GetSalesForYearAsync(request.Year, cancellationToken);

        var reports = groups
            .Select(g => new SalesReport
            {
                Month = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(g.Key),
                Sales = g.Count()
            })
            .OrderBy(r => DateTime.ParseExact(r.Month, "MMMM", CultureInfo.InvariantCulture).Month)
            .ToList();

        return Result<List<SalesReport>>.Success(HttpStatusCode.OK, reports);
    }
}