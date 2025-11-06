using Backend.Application.DTOs.Ram;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.WebApi.Controllers.Base;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/[controller]")]
public class RamsController(IProductService<Ram, RamDto> productService, IFilterService<Ram> filterService)
    : ProductControllerBase<Ram, RamDto>(productService, filterService, ram => ram.Adapt<RamDto>());