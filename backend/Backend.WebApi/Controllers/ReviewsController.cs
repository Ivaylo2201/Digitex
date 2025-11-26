using Backend.Application.Dtos.Review;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/products/{productId:guid}/reviews")]
public class ReviewsController(IReviewService reviewService, IProductBaseService productBaseService) : ControllerBase
{
    [HttpPost]
    [Authorize]
    [ProducesResponseType(typeof(ReviewDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> AddReviewAsync(Guid productId, [FromBody] AddReviewDto body, CancellationToken stoppingToken = default)
    {
        body.UserId = User.GetId();
        body.ProductId = productId;
        
        var review = await reviewService.AddReviewAsync(body, stoppingToken);
        await productBaseService.UpdateRatingAsync(productId, stoppingToken);
        
        return review.IsSuccess ? Ok(review.Value) : BadRequest(review.ErrorObject);
    }
}