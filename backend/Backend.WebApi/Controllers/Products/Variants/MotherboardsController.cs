using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.QueryBuilder;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/[controller]")]
public class MotherboardsController(IProductService<Motherboard, MotherboardDto> productService, IQueryBuilderService<Motherboard> queryBuilderService)
    : ProductControllerBase<Motherboard, MotherboardDto>(productService, queryBuilderService, motherboard => motherboard.Adapt<MotherboardDto>());