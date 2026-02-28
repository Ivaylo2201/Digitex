using Backend.Application.UseCases.Manager.GetCategorySales;
using Backend.Application.UseCases.Manager.GetSalesForYear;
using Backend.Application.UseCases.Manager.GetTotalRevenue;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ManagerController(IMediator mediator) : ControllerBase
{
    [HttpGet("sales/{year:int}")]
    public async Task<Ok<List<SalesReport>>> GetSalesForYearAsync([FromRoute] int year, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetSalesForYearRequest
        {
            Year = year
        }, cancellationToken);

        return TypedResults.Ok(result.Value);
    }
    
    [HttpGet("total-revenue")]
    public async Task<Ok<GetTotalRevenueResponse>> GetTotalRevenueAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetTotalRevenueRequest(), cancellationToken);
        return TypedResults.Ok(result.Value);
    }
    
    [HttpGet("category-sales")]
    public async Task<Ok<List<CategorySaleReport>>> GetCategorySalesReportsAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCategorySalesRequest(), cancellationToken);
        return TypedResults.Ok(result.Value);
    }
}