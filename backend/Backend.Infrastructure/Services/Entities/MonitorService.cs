using Backend.Application.DTOs.Monitor;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Services.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

using Monitor = Domain.Entities.Monitor;

public class MonitorService(
    ILogger<MonitorService> logger,
    IProductRepository<Monitor> monitorRepository,
    ICurrencyService<Monitor> currencyService) : ProductServiceBase<Monitor, MonitorDto>(logger, monitorRepository, currencyService);