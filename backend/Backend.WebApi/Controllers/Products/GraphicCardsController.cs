using Backend.Application.DTOs.GraphicCards;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.WebApi.Controllers.Base;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/[controller]")]
public class GraphicCardsController(IProductService<GraphicCard, GraphicCardDto> productService, IFilterService<GraphicCard> filterService) 
    : ProductControllerBase<GraphicCard, GraphicCardDto>(productService, filterService, graphicCard => graphicCard.Adapt<GraphicCardDto>());