using Backend.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class PowerSupplyRepository(ILogger<PowerSupplyRepository> logger, DatabaseContext context) 
    : ProductRepositoryBase<PowerSupply>(logger, context);