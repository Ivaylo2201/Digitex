using Backend.Application.Contracts.Filters;
using Backend.Application.Interfaces.FiltersProvider;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Filters.Variants;

[ApiController]
[Route("api/filters/power-supplies")]
public class PowerSupplyFiltersController(IFiltersProviderService<PowerSupplyFilters> filtersProviderService)
    : FiltersControllerBase<PowerSupplyFilters>(filtersProviderService);