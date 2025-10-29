using Backend.Application.DTOs.Ssd;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Services.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class SsdService(
    ILogger<SsdService> logger,
    IProductRepository<Ssd> ssdRepository,
    ICurrencyService<Ssd> currencyService) : ProductServiceBase<Ssd, SsdDto>(logger, ssdRepository, currencyService);