using Backend.Application.DTOs;
using Backend.Application.UseCases.Reviews.CreateReview;
using Backend.Application.UseCases.Reviews.GetAllReviewsByProductId;
using Backend.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<Ok<IEnumerable<ReviewDto>>> GetAllReviewsByProductIdAsync([FromQuery] Guid productId, [FromQuery] int limit = 9, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new GetAllReviewsByProductIdRequest { ProductId = productId, Limit = limit }, cancellationToken);
        return TypedResults.Ok(result.Value);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<Results<Created, BadRequest>> CreateReviewAsync([FromBody] CreateReviewRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request.Authorize(HttpContext), cancellationToken);
        
        return result.IsSuccess
            ? TypedResults.Created()
            : TypedResults.BadRequest();
    }
}