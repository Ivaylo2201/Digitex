using Backend.Application.DTOs.Filters;
using Backend.Application.DTOs.Products.Ssd;
using Backend.Application.Interfaces.Services;
using Backend.Application.UseCases.Products.CreateProduct;
using Backend.Application.UseCases.Products.DeleteProduct;
using Backend.Application.UseCases.Products.GetAllProducts;
using Backend.Application.UseCases.Products.GetOneProduct;
using Backend.Application.UseCases.Products.UpdateProduct;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/ssds")]
public class SsdsController(IMediator mediator, IFilterService<SsdFiltersDto> filterService) : ControllerBase
{
    [HttpPost]
    public async Task<Results<Created, BadRequest>> CreateAsync([FromForm] CreateSsdRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? TypedResults.Created() : TypedResults.BadRequest();
    }

    [HttpGet]
    public async Task<Ok<Pagination<SsdDto>>> GetAllAsync([FromQuery] GetAllSsdsRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return TypedResults.Ok(result.Value);
    }

    [HttpGet("{id:guid}")]
    public async Task<Results<Ok<SsdDto>, NotFound>> GetOneAsync([FromRoute] Guid id, [FromQuery] CurrencyIsoCode currency = CurrencyIsoCode.Eur, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new GetOneSsdRequest { Id = id, Currency = currency }, cancellationToken);
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<Results<NoContent, NotFound>> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new DeleteSsdRequestBase { Id = id }, cancellationToken);
        return result.IsSuccess ? TypedResults.NoContent() : TypedResults.NotFound();
    }

    [HttpPut("{id:guid}")]
    public async Task<Results<Ok, BadRequest>> UpdateAsync([FromRoute] Guid id, [FromForm] UpdateSsdRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? TypedResults.Ok() : TypedResults.BadRequest();
    }
    
    [HttpGet("filters")]
    public async Task<Ok<SsdFiltersDto>> GetFiltersAsync(CancellationToken cancellationToken)
        => TypedResults.Ok(await filterService.GetFiltersAsync(cancellationToken));
}
