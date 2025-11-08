using Backend.Domain.Entities;
using Backend.Infrastructure.Database.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Entities;

public class ProcessorRepository(ILogger<ProcessorRepository> logger, DatabaseContext context) 
    : ProductRepositoryBase<Processor>(logger, context);