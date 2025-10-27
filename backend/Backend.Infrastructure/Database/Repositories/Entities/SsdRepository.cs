using Backend.Domain.Entities;
using Backend.Infrastructure.Database.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class SsdRepository(ILogger<SsdRepository> logger, DatabaseContext context) 
    : ProductRepositoryBase<Ssd>(logger, context);