using System.Linq.Expressions;
using Backend.Application.DTOs.Products;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using MediatR;

namespace Backend.Application.Interfaces.Services;

public interface IProductService<TProduct, TProjection, in TCreate, in TUpdate> where TProduct : ProductBase
{
    Task<Result<TProjection?>> GetOneAsync(Guid id, CurrencyIsoCode currency, CancellationToken cancellationToken);
    Task<Result<Pagination<ProductSummaryDto>>> GetAllAsync(int page, int pageSize, CurrencyIsoCode currency, Expression<Func<TProduct, bool>> filter, CancellationToken cancellationToken);
    Task<Result<TProjection>> CreateAsync(TCreate product, CancellationToken cancellationToken);
    Task<Result<Unit>> UpdateAsync(Guid id, TUpdate product, CancellationToken cancellationToken);
    Task<Result<Unit>> DeleteAsync(Guid id, CancellationToken cancellationToken);
}