using Backend.Application.Dtos.Admin;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController(IProductBaseService productService) : ControllerBase
{
    [HttpPost("add-suggestion")]
    [Consumes("application/json")]
    [Produces("application/json")]  
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorObject), StatusCodes.Status404NotFound)]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddSuggestionAsync([FromBody] AddSuggestionDto body, CancellationToken stoppingToken = default)
    {
        var result = await productService.AddSuggestionAsync(body, stoppingToken);
        return result.IsSuccess ? Ok() : NotFound(result.ErrorObject);
    }
}