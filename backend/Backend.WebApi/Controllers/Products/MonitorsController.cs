using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces.Services;
using Backend.WebApi.Controllers.Base;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

using Monitor = Backend.Domain.Entities.Monitor;

[ApiController]
[Route("api/products/[controller]")]
public class MonitorsController(IProductService<Monitor, MonitorDto> productService, IFilterService<Monitor> filterService)
    : ProductControllerBase<Monitor, MonitorDto>(productService, filterService, monitor => monitor.Adapt<MonitorDto>());