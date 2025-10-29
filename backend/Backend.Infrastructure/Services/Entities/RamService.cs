using Backend.Application.DTOs.Ram;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Services.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class RamService(
    ILogger<RamService> logger,
    IProductRepository<Ram> ramRepository,
    ICurrencyService<Ram> currencyService) : ProductServiceBase<Ram, RamDto>(logger, ramRepository, currencyService);