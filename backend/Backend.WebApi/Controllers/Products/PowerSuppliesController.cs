using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/power-supplies")]
public class PowerSuppliesController(IProductService<PowerSupply, PowerSupplyDto> productService, IFilterService<PowerSupply> filterService) 
    : ProductControllerBase<PowerSupply, PowerSupplyDto>(productService, filterService, powerSupply => powerSupply.Adapt<PowerSupplyDto>());