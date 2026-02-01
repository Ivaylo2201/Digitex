using Backend.Domain.Entities;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class GraphicsCardRepository(DatabaseContext context) : ProductRepositoryBase<GraphicsCard>(context);