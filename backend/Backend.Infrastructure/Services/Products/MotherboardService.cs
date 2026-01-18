using Backend.Application.Contracts.Product.Variants;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class MotherboardService(
    ILogger<MotherboardService> logger,
    IProductRepository<Motherboard> motherboardRepository,
    IExchangeRepository exchangeRateRepository,
    ICurrencyService currencyService) : ProductServiceBase<Motherboard, MotherboardProjection>(logger, motherboardRepository, exchangeRateRepository, currencyService);