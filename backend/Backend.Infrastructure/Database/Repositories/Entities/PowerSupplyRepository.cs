using Backend.Domain.Entities;
using Backend.Infrastructure.Database.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class PowerSupplyRepository(ILogger<PowerSupplyRepository> logger, DatabaseContext context) 
    : ProductRepositoryBase<PowerSupply>(logger, context);