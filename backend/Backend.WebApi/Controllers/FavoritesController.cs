using Backend.Application.DTOs.Products;
using Backend.Application.UseCases.Favorites.GetUserFavorites;
using Backend.Application.UseCases.Favorites.ToggleFavorite;
using Backend.Infrastructure.Extensions;
using Backend.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController(IMediator mediator) : ControllerBase
{
    [HttpPost("toggle")]
    [Authorize]
    public async Task<Results<Ok, NotFound<ProblemDetails>>> ToggleFavoriteAsync([FromBody] ToggleFavoriteRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request.Authorize(HttpContext), cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Ok()
            : TypedResults.NotFound(result.ToProblemDetails());
    }
    
    [HttpGet]
    [Authorize]
    public async Task<Results<Ok<IEnumerable<ProductSummaryDto>>, NotFound<ProblemDetails>>> GetUserFavorites(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetUserFavoritesRequest().Authorize(HttpContext), cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound(result.ToProblemDetails());
    }
}