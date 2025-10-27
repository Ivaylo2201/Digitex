using Backend.Domain.Entities;
using Backend.Infrastructure.Database.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class GpuRepository(ILogger<GpuRepository> logger, DatabaseContext context) 
    : ProductRepositoryBase<Gpu>(logger, context);