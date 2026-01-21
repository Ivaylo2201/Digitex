using Backend.Application.Contracts.Product.Variants;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products.Variants;

[ApiController]
[Route("api/products/[controller]")]
public class ProcessorsController(IProductService<Processor, ProcessorProjection> productService, IQueryBuilderService<Processor> queryBuilderService) 
    : ProductControllerBase<Processor, ProcessorProjection>(productService, queryBuilderService, processor => processor.Adapt<ProcessorProjection>());