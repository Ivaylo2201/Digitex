using Backend.Application.Dtos.Product;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;

namespace Backend.Application.Interfaces;

public interface IProductService<TProduct, TProjection> where TProduct : ProductBase
{
    Task<Result<TProjection?>> GetOneAsync(Guid id, Func<TProduct, TProjection> project, CurrencyIsoCode currencyIsoCode, CancellationToken stoppingToken = default);
    Task<Result<PaginatedResponse<IReadOnlyList<ProductShortDto>>>> ListAllAsync(int page, int pageSize, Query<TProduct> query, CurrencyIsoCode currencyIsoCode, CancellationToken stoppingToken = default);
    //Task<Result<List<TProjection>>> AdminListAllAsync(CurrencyIsoCode currencyIsoCode, CancellationToken stoppingToken = default);
}