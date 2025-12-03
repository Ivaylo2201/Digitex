using Backend.Application.Dtos.Review;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Infrastructure.Extensions;
using Backend.WebApi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/products/{productId:guid}/reviews")]
public class ReviewsController(IReviewService reviewService, IProductBaseService productBaseService) : ControllerBase
{
    [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(ReviewDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status400BadRequest)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> AddReviewAsync(Guid productId, [FromBody] AddReviewDto body, CancellationToken stoppingToken = default)
    {
        body.UserId = User.GetId();
        body.ProductId = productId;
        
        var result = await reviewService.AddReviewAsync(body, stoppingToken);
        await productBaseService.UpdateRatingAsync(productId, stoppingToken);
        
        return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorObject);
    }
}