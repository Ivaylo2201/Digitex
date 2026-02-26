using Backend.Application.DTOs.Filters;
using Backend.Application.DTOs.Products.GraphicsCard;
using Backend.Application.Interfaces.Services;
using Backend.Application.UseCases.Products.AddSuggestion;
using Backend.Application.UseCases.Products.CreateProduct;
using Backend.Application.UseCases.Products.DeleteProduct;
using Backend.Application.UseCases.Products.GetAllProducts;
using Backend.Application.UseCases.Products.GetOneProduct;
using Backend.Application.UseCases.Products.RemoveSuggestion;
using Backend.Application.UseCases.Products.UpdateProduct;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/graphics-cards")]
public class GraphicsCardsController(IMediator mediator, IFilterService<GraphicsCardFiltersDto> filterService) : ControllerBase
{
    [HttpPost]
    //[Authorize(Roles = nameof(Role.Admin))]
    public async Task<Results<Created, BadRequest>> CreateAsync([FromForm] CreateGraphicsCardRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);

        return result.IsSuccess
            ? TypedResults.Created()
            : TypedResults.BadRequest();
    }
    
    [HttpGet]
    public async Task<Ok<Pagination<GraphicsCardDto>>> GetAllAsync([FromQuery] GetAllGraphicsCardsRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return TypedResults.Ok(result.Value);
    }

    [HttpGet("{id:guid}")]
    public async Task<Results<Ok<GraphicsCardDto>, NotFound>> GetOneAsync([FromRoute] Guid id, [FromQuery] CurrencyIsoCode currency = CurrencyIsoCode.Eur, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new GetOneGraphicsCardRequest { Id = id, Currency = currency }, cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound();
    }

    [HttpDelete("{id:guid}")]
    //[Authorize(Roles = nameof(Role.Admin))]
    public async Task<Results<NoContent, NotFound>> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new DeleteGraphicsCardRequestBase { Id = id }, cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.NoContent()
            : TypedResults.NotFound();
    }

    [HttpPut("{id:guid}")]
    //[Authorize(Roles = nameof(Role.Admin))]
    public async Task<Results<Ok, BadRequest>> UpdateAsync([FromRoute] Guid id, [FromForm] UpdateGraphicsCardRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var result = await mediator.Send(request, cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Ok()
            : TypedResults.BadRequest();
    }
    
    [HttpGet("filters")]
    public async Task<Ok<GraphicsCardFiltersDto>> GetFiltersAsync(CancellationToken cancellationToken)
        => TypedResults.Ok(await filterService.GetFiltersAsync(cancellationToken));
    
    [HttpPost("suggestions")]
    public async Task<Ok> AddSuggestionAsync([FromBody] AddSuggestionRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return TypedResults.Ok();
    }
    
    [HttpDelete("{productId:guid}/suggestions/{suggestionSku}")]
    public async Task<NoContent> RemoveSuggestionAsync([FromRoute] Guid productId, [FromRoute] string suggestionSku, CancellationToken cancellationToken)
    {
        await mediator.Send(new RemoveSuggestionRequest
        {
            ProductId = productId,
            SuggestedProductSku = suggestionSku
        }, cancellationToken);
        
        return TypedResults.NoContent();
    }
}