using Backend.Application.DTOs.Cpu;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.WebApi.Controllers.Base;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/[controller]")]
public class CpusController(IProductService<Cpu, CpuDto> productService, IFilterService<Cpu> filterService) 
    : ProductControllerBase<Cpu, CpuDto>(productService, filterService, cpu => cpu.Adapt<CpuDto>());