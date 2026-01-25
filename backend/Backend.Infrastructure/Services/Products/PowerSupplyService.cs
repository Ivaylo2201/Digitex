using Backend.Application.DTOs.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class PowerSupplyService(
    ILogger<PowerSupplyService> logger,
    IProductRepository<PowerSupply> powerSupplyRepository,
    IExchangeRepository exchangeRateRepository,
    ICurrencyService currencyService) : ProductServiceBase<PowerSupply, PowerSupplyDto>(logger, powerSupplyRepository, exchangeRateRepository, currencyService);