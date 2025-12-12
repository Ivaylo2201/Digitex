using Backend.Application.Dtos.Products;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class ProcessorService(ILogger<ProcessorService> logger, IProductRepository<Processor> processorRepository, IExchangeRateRepository exchangeRateRepository) 
    : ProductServiceBase<Processor, ProcessorDto>(logger, processorRepository, exchangeRateRepository);