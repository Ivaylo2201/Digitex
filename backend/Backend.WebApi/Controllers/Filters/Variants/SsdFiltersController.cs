using Backend.Application.Contracts.Filters;
using Backend.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Filters.Variants;

[ApiController]
[Route("api/filters/ssds")]
public class SsdFiltersController(IFiltersProviderService<SsdFilters> filtersProviderService)
    : FiltersControllerBase<SsdFilters>(filtersProviderService);