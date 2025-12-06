using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.WebApi.Controllers.Base;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers.Products;

[ApiController]
[Route("api/products/[controller]")]
public class ProcessorsController(IProductService<Processor, ProcessorDto> productService, IFilterService<Processor> filterService) 
    : ProductControllerBase<Processor, ProcessorDto>(productService, filterService, processor => processor.Adapt<ProcessorDto>());