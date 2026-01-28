using Backend.Application.DTOs.Products.Processor;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class ProcessorService(
    ILogger<ProcessorService> logger,
    IProductRepository<Processor> processorRepository,
    IExchangeRepository exchangeRateRepository,
    ICurrencyService currencyService,
    IValidator<Processor> validator) : ProductServiceBase<Processor, ProcessorDto>(logger, processorRepository, exchangeRateRepository, currencyService, validator);