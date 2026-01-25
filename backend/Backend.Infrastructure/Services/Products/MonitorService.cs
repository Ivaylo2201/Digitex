using Backend.Application.DTOs.Products;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

using Monitor = Domain.Entities.Monitor;

public class MonitorService(
    ILogger<MonitorService> logger,
    IProductRepository<Monitor> monitorRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService) : ProductServiceBase<Monitor, MonitorDto>(logger, monitorRepository, exchangeRepository, currencyService);