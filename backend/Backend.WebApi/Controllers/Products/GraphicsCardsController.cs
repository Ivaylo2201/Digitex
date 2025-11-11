using Backend.Application.Dtos.GraphicsCards;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.WebApi.Controllers.Base;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/graphics-cards")]
public class GraphicsCardsController(IProductService<GraphicsCard, GraphicsCardDto> productService, IFilterService<GraphicsCard> filterService) 
    : ProductControllerBase<GraphicsCard, GraphicsCardDto>(productService, filterService, graphicCard => graphicCard.Adapt<GraphicsCardDto>());