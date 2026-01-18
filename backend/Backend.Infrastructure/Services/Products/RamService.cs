using Backend.Application.Contracts.Product.Variants;
using Backend.Application.Interfaces;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class RamService(
    ILogger<RamService> logger,
    IProductRepository<Ram> ramRepository,
    IExchangeRepository exchangeRateRepository,
    ICurrencyService currencyService) : ProductServiceBase<Ram, RamProjection>(logger, ramRepository, exchangeRateRepository, currencyService);