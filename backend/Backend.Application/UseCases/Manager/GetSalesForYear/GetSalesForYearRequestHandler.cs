using System.Globalization;
using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Manager.GetSalesForYear;

public class GetSalesForYearRequestHandler(
    ILogger<GetSalesForYearRequestHandler> logger,
    ISaleRepository saleRepository) : IRequestHandler<GetSalesForYearRequest, Result<List<SalesReport>>>
{
    private const string Source = nameof(GetSalesForYearRequestHandler);
    
    public async Task<Result<List<SalesReport>>> Handle(GetSalesForYearRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("[{Source}]: Getting all sales for {Year}...", Source, request.Year);
        var groups = await saleRepository.GetSalesForYearAsync(request.Year, cancellationToken);

        var reports = groups
            .Select(g => new SalesReport
            {
                Month = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(g.Key),
                Sales = g.Count(),
                Revenue = g.Sum(sale => sale.QuantitySold * sale.Product.Price)
            })
            .OrderBy(r => DateTime.ParseExact(r.Month, "MMMM", CultureInfo.InvariantCulture).Month)
            .ToList();

        return Result<List<SalesReport>>.Success(HttpStatusCode.OK, reports);
    }
}