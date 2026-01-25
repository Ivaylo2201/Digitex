using Backend.Application.DTOs.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class MotherboardService(
    ILogger<MotherboardService> logger,
    IProductRepository<Motherboard> motherboardRepository,
    IExchangeRepository exchangeRateRepository,
    ICurrencyService currencyService) : ProductServiceBase<Motherboard, MotherboardDto>(logger, motherboardRepository, exchangeRateRepository, currencyService);