using Backend.Infrastructure.Database.Repositories.Base;
using Microsoft.Extensions.Logging;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class MonitorRepository(ILogger<MonitorRepository> logger, DatabaseContext context) 
    : ProductRepositoryBase<Monitor>(logger, context);