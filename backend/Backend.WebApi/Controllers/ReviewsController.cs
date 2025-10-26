using Backend.Application.CQRS.Entities.Review.Commands;
using Backend.Application.CQRS.Entities.Review.Queries;
using Backend.Application.DTOs.Review;
using Backend.Domain.Entities;
using Backend.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleSoft.Mediator;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/products/{productId:guid}/reviews")]
public class ReviewsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Authorize]
    [ProducesResponseType(typeof(Review), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddReviewAsync(Guid productId, [FromBody] AddReviewDto body, CancellationToken ct = default)
    {
        body.UserId = User.GetId();
        body.ProductId = productId;
        
        var review = await mediator.SendAsync(new AddReviewCommand(body), ct);
        
        return Created(string.Empty, review.Value);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ReviewDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetReviewsAsync(Guid productId, CancellationToken ct = default)
    {
        var reviews = await mediator.FetchAsync(new ListReviewsQuery { ProductId = productId }, ct);
        return Ok(reviews.Value);   
    }
}