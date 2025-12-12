using Backend.Application.Dtos.Products;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class SsdService(ILogger<SsdService> logger, IProductRepository<Ssd> ssdRepository, IExchangeRateRepository exchangeRateRepository) 
    : ProductServiceBase<Ssd, SsdDto>(logger, ssdRepository, exchangeRateRepository);