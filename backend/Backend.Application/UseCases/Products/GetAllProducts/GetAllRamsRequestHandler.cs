using Backend.Application.DTOs.Products.Ram;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.GetAllProducts;

public record GetAllRamsRequest : GetAllProductsRequestBase<RamDto>;

public class GetAllRamsRequestHandler(
    IProductRepository<Ram> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService,
    IExpressionBuilderService<Ram> expressionBuilderService) 
    : GetAllProductsRequestHandlerBase<GetAllRamsRequest, Ram, RamDto>(productRepository, exchangeRepository, currencyService, expressionBuilderService);