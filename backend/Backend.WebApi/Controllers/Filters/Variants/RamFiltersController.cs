using Backend.Application.Dtos.Filters;
using Backend.Application.Interfaces.FiltersProvider;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Filters.Variants;

[ApiController]
[Route("api/filters/ram")]
public class RamFiltersController(IFiltersProviderService<RamFilters> filtersProviderService)
    : FiltersControllerBase<RamFilters>(filtersProviderService);