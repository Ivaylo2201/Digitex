using Backend.Application.DTOs.Filters;
using Backend.Application.DTOs.Products.Ram;
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
[Route("api/products/rams")]
public class RamsController(IMediator mediator, IFilterService<RamFiltersDto> filterService) : ControllerBase
{
    [HttpPost]
    public async Task<Results<Created, BadRequest>> CreateAsync([FromForm] CreateRamRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? TypedResults.Created() : TypedResults.BadRequest();
    }

    [HttpGet]
    public async Task<Ok<Pagination<RamDto>>> GetAllAsync([FromQuery] GetAllRamsRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return TypedResults.Ok(result.Value);
    }

    [HttpGet("{id:guid}")]
    public async Task<Results<Ok<RamDto>, NotFound>> GetOneAsync([FromRoute] Guid id, [FromQuery] CurrencyIsoCode currency, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetOneRamRequest { Id = id }, cancellationToken);
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<Results<NoContent, NotFound>> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new DeleteRamRequestBase { Id = id }, cancellationToken);
        return result.IsSuccess ? TypedResults.NoContent() : TypedResults.NotFound();
    }

    [HttpPut("{id:guid}")]
    public async Task<Results<Ok, BadRequest>> UpdateAsync([FromRoute] Guid id, [FromForm] UpdateRamRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var result = await mediator.Send(request, cancellationToken);
        return result.IsSuccess ? TypedResults.Ok() : TypedResults.BadRequest();
    }
    
    [HttpGet("filters")]
    public async Task<Ok<RamFiltersDto>> GetFiltersAsync(CancellationToken cancellationToken)
        => TypedResults.Ok(await filterService.GetFiltersAsync(cancellationToken));
}
