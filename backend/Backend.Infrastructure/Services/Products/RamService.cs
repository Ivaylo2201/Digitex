using Backend.Application.DTOs.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class RamService(
    ILogger<RamService> logger,
    IProductRepository<Ram> ramRepository,
    IExchangeRepository exchangeRateRepository,
    ICurrencyService currencyService) : ProductServiceBase<Ram, RamDto>(logger, ramRepository, exchangeRateRepository, currencyService);