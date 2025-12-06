using Microsoft.Extensions.Logging;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class MonitorRepository(ILogger<MonitorRepository> logger, DatabaseContext context) 
    : ProductRepositoryBase<Monitor>(logger, context);