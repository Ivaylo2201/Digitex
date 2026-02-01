using Backend.Domain.Entities;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class MotherboardRepository(DatabaseContext context) : ProductRepositoryBase<Motherboard>(context);