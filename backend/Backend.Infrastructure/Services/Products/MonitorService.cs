using Backend.Application.DTOs.Products.Monitor;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

using Monitor = Domain.Entities.Monitor;

public class MonitorService(
    ILogger<MonitorService> logger,
    IProductRepository<Monitor> monitorRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService,
    IValidator<Monitor> validator) : ProductServiceBase<Monitor, MonitorDto>(logger, monitorRepository, exchangeRepository, currencyService, validator);