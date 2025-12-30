using Backend.Application.Dtos.Products;
using Backend.Application.Interfaces;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

using Monitor = Domain.Entities.Monitor;

public class MonitorService(
    ILogger<MonitorService> logger,
    IProductRepository<Monitor> monitorRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService) : ProductServiceBase<Monitor, MonitorDto>(logger, monitorRepository, exchangeRepository, currencyService);