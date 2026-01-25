using Backend.Application.DTOs.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class GraphicsCardService(
    ILogger<GraphicsCardService> logger,
    IProductRepository<GraphicsCard> graphicCardRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService) : ProductServiceBase<GraphicsCard, GraphicsCardDto>(logger, graphicCardRepository, exchangeRepository, currencyService);