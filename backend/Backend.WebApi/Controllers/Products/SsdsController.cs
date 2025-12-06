using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.WebApi.Controllers.Base;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/[controller]")]
public class SsdsController(IProductService<Ssd, SsdDto> productService, IFilterService<Ssd> filterService)
    : ProductControllerBase<Ssd, SsdDto>(productService, filterService, ssd => ssd.Adapt<SsdDto>());