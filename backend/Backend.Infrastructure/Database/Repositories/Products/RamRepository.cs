using Backend.Domain.Entities;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class RamRepository(DatabaseContext context) : ProductRepositoryBase<Ram>(context);