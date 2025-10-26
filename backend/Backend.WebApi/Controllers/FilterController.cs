using Backend.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;


[ApiController]
[Route("api/filters")]
public class FilterController([FromServices] IFilterProviderService filterProviderService) : ControllerBase
{   
    [HttpGet("ssds")]
    public IActionResult GetSsdFilters() => Ok(filterProviderService.GetSsdFilters());
    
    [HttpGet("cpus")]
    public IActionResult GetCpusFilters() => Ok(filterProviderService.GetCpuFilters());
}