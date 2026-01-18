using Backend.Application.Contracts.Filters;
using Backend.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Filters.Variants;

[Route("api/filters/graphics-cards")]
public class GraphicsCardFiltersController(IFiltersProviderService<GraphicsCardFilters> filtersProviderService)
    : FiltersControllerBase<GraphicsCardFilters>(filtersProviderService);