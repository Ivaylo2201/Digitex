using Backend.Application.DTOs.Products.GraphicsCard;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.GetOneProduct;

public record GetOneGraphicsCardRequest : GetOneProductRequestBase<GraphicsCardDto>;

public class GetOneGraphicsCardRequestHandler(
    IProductRepository<GraphicsCard> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService) : GetOneProductRequestHandlerBase<GetOneGraphicsCardRequest, GraphicsCard, GraphicsCardDto>(productRepository, exchangeRepository, currencyService);