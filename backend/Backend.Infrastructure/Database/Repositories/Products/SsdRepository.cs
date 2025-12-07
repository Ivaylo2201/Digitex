using Backend.Domain.Entities;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class SsdRepository(DatabaseContext context) 
    : ProductRepositoryBase<Ssd>(context);