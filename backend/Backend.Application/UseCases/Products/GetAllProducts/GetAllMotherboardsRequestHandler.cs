using Backend.Application.DTOs.Products.Motherboard;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.GetAllProducts;

public record GetAllMotherboardsRequest : GetAllProductsRequestBase<MotherboardDto>;

public class GetAllMotherboardsRequestHandler(
    IProductRepository<Motherboard> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService,
    IExpressionBuilderService<Motherboard> expressionBuilderService) : GetAllProductsRequestHandlerBase<GetAllMotherboardsRequest, Motherboard, MotherboardDto>(productRepository, exchangeRepository, currencyService, expressionBuilderService);