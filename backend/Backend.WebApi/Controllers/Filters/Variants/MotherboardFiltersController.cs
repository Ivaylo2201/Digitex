using Backend.Application.Contracts.Filters;
using Backend.Application.Interfaces.FiltersProvider;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Filters.Variants;

[ApiController]
[Route("api/filters/motherboards")]
public class MotherboardFiltersController(IFiltersProviderService<MotherboardFilters> filtersProviderService)
    : FiltersControllerBase<MotherboardFilters>(filtersProviderService);