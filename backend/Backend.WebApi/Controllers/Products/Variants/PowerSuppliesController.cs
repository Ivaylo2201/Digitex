using Backend.Application.Contracts.Product.Variants;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.QueryBuilder;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/power-supplies")]
public class PowerSuppliesController(IProductService<PowerSupply, PowerSupplyProjection> productService, IQueryBuilderService<PowerSupply> queryBuilderService) 
    : ProductControllerBase<PowerSupply, PowerSupplyProjection>(productService, queryBuilderService, powerSupply => powerSupply.Adapt<PowerSupplyProjection>());