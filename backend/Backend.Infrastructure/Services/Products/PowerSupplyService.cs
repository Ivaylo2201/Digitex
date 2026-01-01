using Backend.Application.Contracts.Product.Variants;
using Backend.Application.Interfaces;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class PowerSupplyService(
    ILogger<PowerSupplyService> logger,
    IProductRepository<PowerSupply> powerSupplyRepository,
    IExchangeRepository exchangeRateRepository,
    ICurrencyService currencyService) : ProductServiceBase<PowerSupply, PowerSupplyProjection>(logger, powerSupplyRepository, exchangeRateRepository, currencyService);