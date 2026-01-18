using Backend.Application.Contracts.Product;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;

namespace Backend.Application.Interfaces.Services;

public interface IProductService<TProduct, TProjection> where TProduct : ProductBase
{
    Task<Result<TProjection?>> GetOneAsync(Guid id, Func<TProduct, TProjection> project, CurrencyIsoCode currencyIsoCode, CancellationToken cancellationToken = default);
    Task<Result<PaginatedResponse<IReadOnlyList<ProductSummary>>>> ListAllAsync(int page, int pageSize, Query<TProduct> query, CurrencyIsoCode currencyIsoCode, CancellationToken cancellationToken = default);
}