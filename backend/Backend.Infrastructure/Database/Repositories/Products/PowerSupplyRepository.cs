using Backend.Domain.Entities;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class PowerSupplyRepository(DatabaseContext context) : ProductRepositoryBase<PowerSupply>(context);