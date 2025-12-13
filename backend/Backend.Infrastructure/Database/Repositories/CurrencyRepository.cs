using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class CurrencyRepository(DatabaseContext context) : ICurrencyRepository
{
    public async Task<List<Currency>> ListAllAsync(Filter<Currency>? filter = null, CancellationToken stoppingToken = default)
        => await context.Currencies.ToListAsync(stoppingToken);
}