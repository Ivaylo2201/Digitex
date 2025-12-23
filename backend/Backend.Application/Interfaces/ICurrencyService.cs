using Backend.Application.Dtos;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces;

public interface ICurrencyService
{
    Task<Result<List<CurrencyDto>>> ListAllAsync(CancellationToken stoppingToken = default);
}