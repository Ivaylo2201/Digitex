using Backend.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class RamRepository(ILogger<RamRepository> logger, DatabaseContext context) 
    : ProductRepositoryBase<Ram>(logger, context);
