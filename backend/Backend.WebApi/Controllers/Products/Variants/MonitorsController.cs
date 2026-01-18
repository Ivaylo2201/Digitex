using Backend.Application.Contracts.Product.Variants;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

using Monitor = Domain.Entities.Monitor;

[ApiController]
[Route("api/products/[controller]")]
public class MonitorsController(IProductService<Monitor, MonitorProjection> productService, IQueryBuilderService<Monitor> queryBuilderService) 
    : ProductControllerBase<Monitor, MonitorProjection>(productService, queryBuilderService, monitor => monitor.Adapt<MonitorProjection>());