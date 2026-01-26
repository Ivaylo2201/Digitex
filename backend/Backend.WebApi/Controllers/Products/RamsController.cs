using Backend.Application.DTOs;
using Backend.Application.DTOs.Filters;
using Backend.Application.DTOs.Products;
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
    IFiltersProviderService<RamFiltersDto> filtersProviderService)
    : ProductControllerBase<Ram, RamDto, RamFiltersDto>(productService, expressionBuilderService, filtersProviderService);