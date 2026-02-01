using Backend.Application.DTOs.Products.Monitor;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Interfaces.Repositories;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Application.UseCases.Products.GetAllProducts;

public record GetAllMonitorsRequest : GetAllProductsRequestBase<MonitorDto>;

public class GetAllMonitorsRequestHandler(
    IProductRepository<Monitor> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService,
    IExpressionBuilderService<Monitor> expressionBuilderService) : GetAllProductsRequestHandlerBase<GetAllMonitorsRequest, Monitor, MonitorDto>(productRepository, exchangeRepository, currencyService, expressionBuilderService);