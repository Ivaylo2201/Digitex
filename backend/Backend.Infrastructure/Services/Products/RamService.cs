using Backend.Application.DTOs.Products;
using Backend.Application.DTOs.Products.Ram;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class RamService(
    ILogger<RamService> logger,
    IProductRepository<Ram> ramRepository,
    IExchangeRepository exchangeRateRepository,
    ICurrencyService currencyService,
    IValidator<Ram> validator) : ProductServiceBase<Ram, RamDto>(logger, ramRepository, exchangeRateRepository, currencyService, validator);