using Backend.Application.DTOs.Products.Processor;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.GetAllProducts;

public record GetAllProcessorsRequest : GetAllProductsRequestBase<ProcessorDto>;
    
public class GetAllProcessorsRequestHandler(
    IProductRepository<Processor> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService,
    IExpressionBuilderService<Processor> expressionBuilderService) : GetAllProductsRequestHandlerBase<GetAllProcessorsRequest, Processor, ProcessorDto>(productRepository, exchangeRepository, currencyService, expressionBuilderService);