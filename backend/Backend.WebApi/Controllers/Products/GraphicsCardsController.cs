using Backend.Application.DTOs;
using Backend.Application.DTOs.Filters;
using Backend.Application.DTOs.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/graphics-cards")]
public class GraphicsCardsController(
    IProductService<GraphicsCard, GraphicsCardDto> productService,
    IExpressionBuilderService<GraphicsCard> expressionBuilderService,
    IFiltersProviderService<GraphicsCardFiltersDto> filtersProviderService) 
    : ProductControllerBase<GraphicsCard, GraphicsCardDto, GraphicsCardFiltersDto>(productService, expressionBuilderService, filtersProviderService);