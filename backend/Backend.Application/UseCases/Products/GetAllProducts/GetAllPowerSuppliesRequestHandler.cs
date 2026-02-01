using Backend.Application.DTOs.Products.PowerSupply;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.GetAllProducts;

public record GetAllPowerSuppliesRequest : GetAllProductsRequestBase<PowerSupplyDto>;

public class GetAllPowerSuppliesRequestHandler(
    IProductRepository<PowerSupply> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService,
    IExpressionBuilderService<PowerSupply> expressionBuilderService) 
    : GetAllProductsRequestHandlerBase<GetAllPowerSuppliesRequest, PowerSupply, PowerSupplyDto>(productRepository, exchangeRepository, currencyService, expressionBuilderService);