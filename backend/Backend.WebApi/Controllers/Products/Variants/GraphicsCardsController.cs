using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.QueryBuilder;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/graphics-cards")]
public class GraphicsCardsController(IProductService<GraphicsCard, GraphicsCardDto> productService, IQueryBuilderService<GraphicsCard> queryBuilderService) 
    : ProductControllerBase<GraphicsCard, GraphicsCardDto>(productService, queryBuilderService, graphicCard => graphicCard.Adapt<GraphicsCardDto>());