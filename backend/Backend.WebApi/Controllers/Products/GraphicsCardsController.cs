using Backend.Application.DTOs.Filters;
using Backend.Application.DTOs.Products.GraphicsCard;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/graphics-cards")]
public class GraphicsCardsController(
    IProductService<GraphicsCard, GraphicsCardDto> productService,
    IExpressionBuilderService<GraphicsCard> expressionBuilderService,
    IFilterService<GraphicsCardFiltersDto> filterService)
    : ProductControllerBase<GraphicsCard, GraphicsCardDto, GraphicsCardModifyDto, GraphicsCardFiltersDto>(productService, expressionBuilderService, filterService);