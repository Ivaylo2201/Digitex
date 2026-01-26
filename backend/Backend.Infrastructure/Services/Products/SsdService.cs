using Backend.Application.DTOs.Products;
using Backend.Application.DTOs.Products.Ssd;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class SsdService(
    ILogger<SsdService> logger, 
    IProductRepository<Ssd> ssdRepository, 
    IExchangeRepository exchangeRateRepository,
    ICurrencyService currencyService,
    IValidator<Ssd> validator) : ProductServiceBase<Ssd, SsdDto>(logger, ssdRepository, exchangeRateRepository, currencyService, validator);