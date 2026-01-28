using Backend.Application.DTOs.Filters;
using Backend.Application.DTOs.Products.PowerSupply;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/power-supplies")]
public class PowerSuppliesController(
    IProductService<PowerSupply, PowerSupplyDto> productService,
    IExpressionBuilderService<PowerSupply> expressionBuilderService,
    IFilterService<PowerSupplyFiltersDto> filterService) 
    : ProductControllerBase<PowerSupply, PowerSupplyDto, PowerSupplyModifyDto, PowerSupplyFiltersDto>(productService, expressionBuilderService, filterService);