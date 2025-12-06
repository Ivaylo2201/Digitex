using Backend.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class ProcessorRepository(ILogger<ProcessorRepository> logger, DatabaseContext context) 
    : ProductRepositoryBase<Processor>(logger, context);