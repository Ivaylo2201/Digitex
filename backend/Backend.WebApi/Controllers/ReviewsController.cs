using Backend.Application.DTOs.Review;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/products/{productId:guid}/reviews")]
public class ReviewsController : ControllerBase
{
    [HttpPost]
    [Authorize]
    [ProducesResponseType(typeof(Review), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddReviewAsync(Guid productId, [FromBody] AddReviewDto body, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ReviewDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetReviewsAsync(Guid productId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}