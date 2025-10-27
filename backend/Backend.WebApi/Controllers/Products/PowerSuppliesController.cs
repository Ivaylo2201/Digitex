﻿using Backend.Application.DTOs.PowerSupply;
using Backend.Application.Extensions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/power-supplies")]
public class PowerSuppliesController(IProductService<PowerSupply, PowerSupplyDto> productService, IFilterService<PowerSupply> filterService) 
    : ProductControllerBase<PowerSupply, PowerSupplyDto>(productService, filterService, powerSupply => powerSupply.ToPowerSupplyDto());