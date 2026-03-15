using Backend.Application.DTOs;
using Backend.Application.DTOs.Products;
using Backend.Application.UseCases.Products.AddSuggestion;
using Backend.Application.UseCases.Products.GetSuggested;
using Backend.Application.UseCases.Products.GetSuggestions;
using Backend.Application.UseCases.Products.RemoveSuggestion;
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
    
    [HttpGet("{productId:guid}/suggestions")]
    public async Task<Ok<IEnumerable<SuggestedProductDto>>> GetSuggestionsAsync([FromRoute] Guid productId)
    {
        var result = await mediator.Send(new GetSuggestionsRequest { ProductId = productId });
        return TypedResults.Ok(result.Value);
    }
    
    [HttpGet("{productId:guid}/suggested")]
    public async Task<Ok<IEnumerable<SuggestedProductDto>>> GetSuggestedAsync([FromRoute] Guid productId)
    {
        var result = await mediator.Send(new GetSuggestedRequest { ProductId = productId });
        return TypedResults.Ok(result.Value);
    }
    
    [HttpPost("suggestions")]
    public async Task<Ok> AddSuggestionAsync([FromBody] AddSuggestionRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return TypedResults.Ok();
    }
    
    [HttpDelete("{productId:guid}/suggestions/{suggestionProductId:guid}")]
    public async Task<NoContent> RemoveSuggestionAsync([FromRoute] Guid productId, [FromRoute] Guid suggestionProductId, CancellationToken cancellationToken)
    {
        await mediator.Send(new RemoveSuggestionRequest
        {
            ProductId = productId,
            SuggestedProductId = suggestionProductId
        }, cancellationToken);
        
        return TypedResults.NoContent();
    }
}