using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class MonitorRepository(DatabaseContext context) : ProductRepositoryBase<Monitor>(context);