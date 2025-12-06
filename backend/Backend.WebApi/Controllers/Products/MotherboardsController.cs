using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.WebApi.Controllers.Base;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/[controller]")]
public class MotherboardsController(IProductService<Motherboard, MotherboardDto> productService, IFilterService<Motherboard> filterService) 
    : ProductControllerBase<Motherboard, MotherboardDto>(productService, filterService, motherboard => motherboard.Adapt<MotherboardDto>());