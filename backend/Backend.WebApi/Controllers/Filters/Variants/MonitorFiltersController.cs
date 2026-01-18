using Backend.Application.Contracts.Filters;
using Backend.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Filters.Variants;

[Route("api/filters/monitors")]
public class MonitorFiltersController(IFiltersProviderService<MonitorFilters> filtersProviderService)
    : FiltersControllerBase<MonitorFilters>(filtersProviderService);