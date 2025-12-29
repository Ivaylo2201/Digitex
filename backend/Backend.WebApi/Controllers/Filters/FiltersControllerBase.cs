using Backend.Application.Interfaces.FiltersProvider;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Filters;

public abstract class FiltersControllerBase<TFilters>(IFiltersProviderService<TFilters> filtersProviderService) : ControllerBase
{
    [HttpGet]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> GetFiltersAsync(CancellationToken stoppingToken = default)
        => Ok(await filtersProviderService.ProvideFiltersAsync(stoppingToken));
}