using Backend.Application.DTOs.Gpu;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Services.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class GpuService(
    ILogger<GpuService> logger,
    IProductRepository<Gpu> gpuRepository,
    ICurrencyService<Gpu> currencyService) : ProductServiceBase<Gpu, GpuDto>(logger, gpuRepository, currencyService);