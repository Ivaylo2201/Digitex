using Backend.Application.Contracts.Product.Variants;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/[controller]")]
public class MotherboardsController(IProductService<Motherboard, MotherboardProjection> productService, IQueryBuilderService<Motherboard> queryBuilderService)
    : ProductControllerBase<Motherboard, MotherboardProjection>(productService, queryBuilderService, motherboard => motherboard.Adapt<MotherboardProjection>());