using Backend.Application.DTOs.Filters;
using Backend.Application.DTOs.Products.Processor;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/[controller]")]
public class ProcessorsController(
    IProductService<Processor, ProcessorDto> productService,
    IExpressionBuilderService<Processor> expressionBuilderService,
    IFilterService<ProcessorFiltersDto> filterService) : ProductControllerBase<Processor, ProcessorDto, ProcessorModifyDto, ProcessorFiltersDto>(productService, expressionBuilderService, filterService);