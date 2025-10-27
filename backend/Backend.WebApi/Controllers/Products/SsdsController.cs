using Backend.Application.DTOs.Ssd;
using Backend.Application.Extensions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/[controller]")]
public class SsdsController(IProductService<Ssd, SsdDto> productService, IFilterService<Ssd> filterService)
    : ProductControllerBase<Ssd, SsdDto>(productService, filterService, ssd => ssd.ToSsdDto());