using Backend.Application.Dtos.Products;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

using Monitor = Domain.Entities.Monitor;

public class MonitorService(ILogger<MonitorService> logger, IProductRepository<Monitor> monitorRepository, IExchangeRateRepository exchangeRateRepository)
    : ProductServiceBase<Monitor, MonitorDto>(logger, monitorRepository, exchangeRateRepository);