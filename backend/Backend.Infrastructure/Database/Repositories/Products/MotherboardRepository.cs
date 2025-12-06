using Backend.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Database.Repositories.Products;

public class MotherboardRepository(ILogger<MotherboardRepository> logger, DatabaseContext context) 
    : ProductRepositoryBase<Motherboard>(logger, context);