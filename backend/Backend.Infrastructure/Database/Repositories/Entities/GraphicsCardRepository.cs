using Backend.Domain.Entities;
using Backend.Infrastructure.Database.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class GraphicsCardRepository(ILogger<GraphicsCardRepository> logger, DatabaseContext context) 
    : ProductRepositoryBase<GraphicsCard>(logger, context);