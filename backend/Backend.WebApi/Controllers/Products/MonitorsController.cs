using Backend.Application.DTOs;
using Backend.Application.DTOs.Filters;
using Backend.Application.DTOs.Products;
using Backend.Application.DTOs.Products.Monitor;
using Backend.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/[controller]")]
public class MonitorsController(
    IProductService<Monitor, MonitorDto> productService,
    IExpressionBuilderService<Monitor> expressionBuilderService,
    IFiltersProviderService<MonitorFiltersDto> filtersProviderService) 
    : ProductControllerBase<Monitor, MonitorDto, MonitorFiltersDto>(productService, expressionBuilderService, filtersProviderService);