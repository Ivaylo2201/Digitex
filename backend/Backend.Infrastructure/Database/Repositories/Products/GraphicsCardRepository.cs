using Backend.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class GraphicsCardRepository(ILogger<GraphicsCardRepository> logger, DatabaseContext context) 
    : ProductRepositoryBase<GraphicsCard>(logger, context);