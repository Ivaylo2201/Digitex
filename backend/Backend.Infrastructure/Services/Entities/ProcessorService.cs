using Backend.Application.Dtos.Processor;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Services.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class ProcessorService(
    ILogger<ProcessorService> logger,
    IProductRepository<Processor> processorRepository) : ProductServiceBase<Processor, ProcessorDto>(logger, processorRepository);