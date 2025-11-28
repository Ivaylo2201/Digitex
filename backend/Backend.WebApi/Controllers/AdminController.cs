using Backend.Application.Dtos.Admin;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController(IProductBaseService productService) : ControllerBase
{
    [HttpPost("add-suggestion")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    [Authorize(Roles = nameof(Role.Admin))]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> AddSuggestionAsync([FromBody] AddSuggestionDto body, CancellationToken stoppingToken = default)
    {
        var result = await productService.AddSuggestionAsync(body, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new { } : result.ErrorObject);
    }
}