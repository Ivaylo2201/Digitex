using Backend.Domain.Entities;
using Backend.Infrastructure.Database.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class GraphicCardRepository(ILogger<GraphicCardRepository> logger, DatabaseContext context) 
    : ProductRepositoryBase<GraphicCard>(logger, context);