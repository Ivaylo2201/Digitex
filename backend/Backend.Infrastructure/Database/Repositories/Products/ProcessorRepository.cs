using Backend.Domain.Entities;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class ProcessorRepository(DatabaseContext context) 
    : ProductRepositoryBase<Processor>(context);