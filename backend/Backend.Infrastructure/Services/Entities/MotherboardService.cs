using Backend.Application.DTOs.Motherboard;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Services.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class MotherboardService(ILogger<MotherboardService> logger, IProductRepository<Motherboard> motherboardRepository) 
    : ProductServiceBase<Motherboard, MotherboardDto>(logger, motherboardRepository);