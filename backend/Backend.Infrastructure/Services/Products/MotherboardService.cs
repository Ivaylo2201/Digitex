using Backend.Application.Dtos.Products;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class MotherboardService(ILogger<MotherboardService> logger, IProductRepository<Motherboard> motherboardRepository, IExchangeRateRepository exchangeRateRepository) 
    : ProductServiceBase<Motherboard, MotherboardDto>(logger, motherboardRepository, exchangeRateRepository);