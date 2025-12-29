using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.QueryBuilder;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/[controller]")]
public class SsdsController(IProductService<Ssd, SsdDto> productService, IQueryBuilderService<Ssd> queryBuilderService) 
    : ProductControllerBase<Ssd, SsdDto>(productService, queryBuilderService, ssd => ssd.Adapt<SsdDto>());