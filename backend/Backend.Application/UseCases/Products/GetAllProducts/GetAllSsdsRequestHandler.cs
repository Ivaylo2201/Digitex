using Backend.Application.DTOs.Products.Ssd;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.GetAllProducts;

public record GetAllSsdsRequest : GetAllProductsRequestBase<SsdDto>;

public class GetAllSsdsRequestHandler(
    IProductRepository<Ssd> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService,
    IExpressionBuilderService<Ssd> expressionBuilderService) 
    : GetAllProductsRequestHandlerBase<GetAllSsdsRequest, Ssd, SsdDto>(productRepository, exchangeRepository, currencyService, expressionBuilderService);