using Backend.Application.Contracts.Product.Variants;
using Backend.Application.Interfaces;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class ProcessorService(
    ILogger<ProcessorService> logger,
    IProductRepository<Processor> processorRepository,
    IExchangeRepository exchangeRateRepository,
    ICurrencyService currencyService) : ProductServiceBase<Processor, ProcessorProjection>(logger, processorRepository, exchangeRateRepository, currencyService);