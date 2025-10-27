using Backend.Application.DTOs.Gpu;
using Backend.Application.Extensions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/[controller]")]
public class GpusController(IProductService<Gpu, GpuDto> productService, IFilterService<Gpu> filterService) 
    : ProductControllerBase<Gpu, GpuDto>(productService, filterService, gpu => gpu.ToGpuDto());