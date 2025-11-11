using Backend.Application.Dtos.Ram;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Services.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class RamService(
    ILogger<RamService> logger,
    IProductRepository<Ram> ramRepository) : ProductServiceBase<Ram, RamDto>(logger, ramRepository);