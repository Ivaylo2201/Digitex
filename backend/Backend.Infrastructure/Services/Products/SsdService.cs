using Backend.Application.Contracts.Product.Variants;
using Backend.Application.Interfaces;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class SsdService(
    ILogger<SsdService> logger, 
    IProductRepository<Ssd> ssdRepository, 
    IExchangeRepository exchangeRateRepository,
    ICurrencyService currencyService) : ProductServiceBase<Ssd, SsdProjection>(logger, ssdRepository, exchangeRateRepository, currencyService);