using Backend.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class SsdRepository(ILogger<SsdRepository> logger, DatabaseContext context) 
    : ProductRepositoryBase<Ssd>(logger, context);