using Backend.Application.Contracts.Product.Variants;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/graphics-cards")]
public class GraphicsCardsController(IProductService<GraphicsCard, GraphicsCardProjection> productService, IQueryBuilderService<GraphicsCard> queryBuilderService) 
    : ProductControllerBase<GraphicsCard, GraphicsCardProjection>(productService, queryBuilderService, graphicCard => graphicCard.Adapt<GraphicsCardProjection>());