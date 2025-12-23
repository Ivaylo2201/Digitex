using Backend.Application.Dtos.Product;
using Backend.Domain.Common;
using Backend.Domain.Enums;

namespace Backend.Application.Interfaces;

public interface IProductService<TEntity, TProjection>
{
    Task<Result<TProjection?>> GetOneAsync(Guid id, Func<TEntity, TProjection> project, CurrencyIsoCode currencyIsoCode, CancellationToken stoppingToken = default);
    Task<Result<List<ProductShortDto>>> ListAllAsync(Filter<TEntity> filter, CurrencyIsoCode currencyIsoCode, CancellationToken stoppingToken = default);
    Task<Result<List<TProjection>>> AdminListAllAsync(CurrencyIsoCode currencyIsoCode, CancellationToken stoppingToken = default);
}