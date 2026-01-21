using Backend.Application.Contracts.Product.Variants;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/graphics-cards")]
public class GraphicsCardsController(IProductService<GraphicsCard, GraphicsCardDto> productService, IQueryBuilderService<GraphicsCard> queryBuilderService) 
    : ProductControllerBase<GraphicsCard, GraphicsCardDto>(productService, queryBuilderService, graphicCard => graphicCard.Adapt<GraphicsCardDto>());