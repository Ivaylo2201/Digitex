using Backend.Application.Contracts.Product.Variants;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/[controller]")]
public class SsdsController(IProductService<Ssd, SsdProjection> productService, IQueryBuilderService<Ssd> queryBuilderService) 
    : ProductControllerBase<Ssd, SsdProjection>(productService, queryBuilderService, ssd => ssd.Adapt<SsdProjection>());