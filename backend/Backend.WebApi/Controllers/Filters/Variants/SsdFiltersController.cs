using Backend.Application.Dtos.Filters;
using Backend.Application.Interfaces.FiltersProvider;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Filters.Variants;

[ApiController]
[Route("api/filters/ssds")]
public class SsdFiltersController(IFiltersProviderService<SsdFilters> filtersProviderService)
    : FiltersControllerBase<SsdFilters>(filtersProviderService);