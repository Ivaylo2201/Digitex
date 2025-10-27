using Backend.Application.DTOs.Gpu;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Services.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class GpuService(ILogger<GpuService> logger, IProductRepository<Gpu> gpuRepository) 
    : ProductServiceBase<Gpu, GpuDto>(logger, gpuRepository);