using Backend.Application.DTOs.Cpu;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Services.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class CpuService(ILogger<CpuService> logger, IProductRepository<Cpu> cpuRepository) 
    : ProductServiceBase<Cpu, CpuDto>(logger, cpuRepository);