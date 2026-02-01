using Backend.Application.DTOs.Products.GraphicsCard;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.GetAllProducts;

public record GetAllGraphicsCardsRequest : GetAllProductsRequestBase<GraphicsCardDto>;
    
public class GetAllGraphicsCardsRequestHandler(
    IProductRepository<GraphicsCard> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService,
    IExpressionBuilderService<GraphicsCard> expressionBuilderService) : GetAllProductsRequestHandlerBase<GetAllGraphicsCardsRequest, GraphicsCard, GraphicsCardDto>(productRepository, exchangeRepository, currencyService, expressionBuilderService);