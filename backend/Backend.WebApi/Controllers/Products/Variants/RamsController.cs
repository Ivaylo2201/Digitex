using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.QueryBuilder;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/[controller]")]
public class RamsController(IProductService<Ram, RamDto> productService, IQueryBuilderService<Ram> queryBuilderService)
    : ProductControllerBase<Ram, RamDto>(productService, queryBuilderService, ram => ram.Adapt<RamDto>());