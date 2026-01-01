using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Database.Repositories;

public class CurrencyRepository(DatabaseContext context) : ICurrencyRepository
{
    public async Task<List<Currency>> ListAllAsync(Query<Currency>? filter = null, CancellationToken cancellationToken = default)
        => await context.Currencies.ToListAsync(cancellationToken);
}