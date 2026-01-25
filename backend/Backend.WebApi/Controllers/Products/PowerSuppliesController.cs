using Backend.Application.DTOs;
using Backend.Application.DTOs.Filters;
using Backend.Application.DTOs.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/power-supplies")]
public class PowerSuppliesController(
    IProductService<PowerSupply, PowerSupplyDto> productService,
    IExpressionBuilderService<PowerSupply> expressionBuilderService,
    IFiltersProviderService<PowerSupplyFiltersDto> filtersProviderService) 
    : ProductControllerBase<PowerSupply, PowerSupplyDto, PowerSupplyFiltersDto>(productService, expressionBuilderService, filtersProviderService);