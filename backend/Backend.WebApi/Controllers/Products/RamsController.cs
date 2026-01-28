using Backend.Application.DTOs.Filters;
using Backend.Application.DTOs.Products.Ram;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/[controller]")]
public class RamsController(
    IProductService<Ram, RamDto> productService,
    IExpressionBuilderService<Ram> expressionBuilderService,
    IFilterService<RamFiltersDto> filterService) : ProductControllerBase<Ram, RamDto, RamModifyDto, RamFiltersDto>(productService, expressionBuilderService, filterService);