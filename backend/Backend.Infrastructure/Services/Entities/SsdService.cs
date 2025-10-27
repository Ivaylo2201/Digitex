using Backend.Application.DTOs.Ssd;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Services.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class SsdService(ILogger<SsdService> logger, IProductRepository<Ssd> ssdRepository) 
    : ProductServiceBase<Ssd, SsdDto>(logger, ssdRepository);