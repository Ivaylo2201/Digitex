using Backend.Domain.Entities;
using Backend.Infrastructure.Database.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class RamRepository(ILogger<RamRepository> logger, DatabaseContext context) 
    : ProductRepositoryBase<Ram>(logger, context);
