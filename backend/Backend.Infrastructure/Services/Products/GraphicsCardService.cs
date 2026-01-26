using Backend.Application.DTOs.Products.GraphicsCard;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class GraphicsCardService(
    ILogger<GraphicsCardService> logger,
    IProductRepository<GraphicsCard> graphicCardRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService,
    IValidator<GraphicsCard> validator) 
    : ProductServiceBase<GraphicsCard, GraphicsCardDto>(logger, graphicCardRepository, exchangeRepository, currencyService, validator);