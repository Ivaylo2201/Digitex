using Backend.Application.DTOs.PowerSupply;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Services.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class PowerSupplyService(
    ILogger<PowerSupplyService> logger,
    IProductRepository<PowerSupply> powerSupplyRepository,
    ICurrencyService<PowerSupply> currencyService) : ProductServiceBase<PowerSupply, PowerSupplyDto>(logger, powerSupplyRepository, currencyService);