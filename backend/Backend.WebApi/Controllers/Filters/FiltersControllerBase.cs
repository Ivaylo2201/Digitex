using Backend.Application.Interfaces.Services;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Filters;

public abstract class FiltersControllerBase<TFilters>(IFiltersProviderService<TFilters> filtersProviderService) : ControllerBase
{
    [HttpGet]
    [Produces(HttpConstants.ApplicationJson)]
    [Consumes(HttpConstants.ApplicationJson)]
    public async Task<Ok<TFilters>> GetFiltersAsync(CancellationToken stoppingToken = default)
        => TypedResults.Ok(await filtersProviderService.ProvideFiltersAsync(stoppingToken));
}