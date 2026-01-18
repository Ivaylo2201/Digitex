using Backend.Application.Contracts.Filters;
using Backend.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Filters.Variants;

[ApiController]
[Route("api/filters/rams")]
public class RamFiltersController(IFiltersProviderService<RamFilters> filtersProviderService)
    : FiltersControllerBase<RamFilters>(filtersProviderService);