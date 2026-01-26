using Backend.Application.DTOs.Filters;
using Backend.Application.DTOs.Products.Ssd;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/[controller]")]
public class SsdsController(
    IProductService<Ssd, SsdDto> productService,
    IExpressionBuilderService<Ssd> expressionBuilderService,
    IFiltersProviderService<SsdFiltersDto> filtersProviderService) : ProductControllerBase<Ssd, SsdDto, SsdFiltersDto>(productService, expressionBuilderService, filtersProviderService);