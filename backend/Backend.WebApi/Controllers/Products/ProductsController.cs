using Backend.Application.DTOs.Products;
using Backend.Application.UseCases.Products.SearchProducts;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpGet("search")]
    public async Task<Ok<IEnumerable<ProductSummaryDto>>> SearchAsync([FromQuery] string query)
    {
        var result = await mediator.Send(new SearchProductsRequest { Query = query });
        return TypedResults.Ok(result.Value);
    }
}