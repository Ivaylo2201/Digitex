using Backend.Application.Dtos.Filters;
using Backend.Application.Interfaces.FiltersProvider;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Filters.Variants;

[ApiController]
[Route("api/filters/motherboard")]
public class MotherboardFiltersController(IFiltersProviderService<MotherboardFilters> filtersProviderService)
    : FiltersControllerBase<MotherboardFilters>(filtersProviderService);