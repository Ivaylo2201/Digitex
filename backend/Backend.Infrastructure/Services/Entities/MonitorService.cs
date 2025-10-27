using Backend.Application.DTOs.Monitor;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Services.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

using Monitor = Domain.Entities.Monitor;

public class MonitorService(ILogger<MonitorService> logger, IProductRepository<Monitor> monitorRepository) 
    : ProductServiceBase<Monitor, MonitorDto>(logger, monitorRepository);