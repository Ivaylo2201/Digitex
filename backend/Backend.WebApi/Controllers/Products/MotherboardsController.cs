using Backend.Application.DTOs;
using Backend.Application.DTOs.Filters;
using Backend.Application.DTOs.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/[controller]")]
public class MotherboardsController(
    IProductService<Motherboard, MotherboardDto> productService,
    IExpressionBuilderService<Motherboard> expressionBuilderService,
    IFiltersProviderService<MotherboardFiltersDto> filtersProviderService)
    : ProductControllerBase<Motherboard, MotherboardDto, MotherboardFiltersDto>(productService, expressionBuilderService, filtersProviderService);