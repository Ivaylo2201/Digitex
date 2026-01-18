using Backend.Application.Contracts.Product.Variants;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class GraphicsCardService(
    ILogger<GraphicsCardService> logger,
    IProductRepository<GraphicsCard> graphicCardRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService) : ProductServiceBase<GraphicsCard, GraphicsCardProjection>(logger, graphicCardRepository, exchangeRepository, currencyService);