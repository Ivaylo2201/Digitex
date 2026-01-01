using Backend.Application.Contracts.Filters;
using Backend.Application.Interfaces.FiltersProvider;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Filters.Variants;

[ApiController]
[Route("api/filters/processors")]
public class ProcessorFiltersController(IFiltersProviderService<ProcessorFilters> filtersProviderService)
    : FiltersControllerBase<ProcessorFilters>(filtersProviderService);