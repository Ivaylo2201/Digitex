using Backend.Application.DTOs.Product;
using Backend.Domain.Common;
using Backend.Domain.Enums;

namespace Backend.Application.Interfaces.Services;

public interface IProductService<TEntity, TProjection>
{
    Task<Result<TProjection?>> GetOneAsync(Guid id, Func<TEntity, TProjection> project, CancellationToken stoppingToken = default);
    Task<Result<List<ProductShortDto>>> ListAllAsync(Filter<TEntity> filter, CancellationToken stoppingToken = default);
}