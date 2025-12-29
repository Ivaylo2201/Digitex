using Backend.Application.Dtos.Filters;
using Backend.Application.Interfaces.FiltersProvider;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Filters.Variants;

[Route("api/filters/graphics-card")]
public class GraphicsCardFiltersController(IFiltersProviderService<GraphicsCardFilters> filtersProviderService)
    : FiltersControllerBase<GraphicsCardFilters>(filtersProviderService);