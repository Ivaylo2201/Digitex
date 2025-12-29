using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.QueryBuilder;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

using Monitor = Domain.Entities.Monitor;

[ApiController]
[Route("api/products/[controller]")]
public class MonitorsController(IProductService<Monitor, MonitorDto> productService, IQueryBuilderService<Monitor> queryBuilderService) 
    : ProductControllerBase<Monitor, MonitorDto>(productService, queryBuilderService, monitor => monitor.Adapt<MonitorDto>());