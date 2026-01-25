using Backend.Application.DTOs;
using Backend.Application.DTOs.Filters;
using Backend.Application.DTOs.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/[controller]")]
public class ProcessorsController(
    IProductService<Processor, ProcessorDto> productService,
    IExpressionBuilderService<Processor> expressionBuilderService,
    IFiltersProviderService<ProcessorFiltersDto> filtersProviderService)
    : ProductControllerBase<Processor, ProcessorDto, ProcessorFiltersDto>(productService, expressionBuilderService, filtersProviderService);