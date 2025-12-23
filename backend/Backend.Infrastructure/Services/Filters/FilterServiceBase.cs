using Backend.Application.Interfaces.Filters;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;

namespace Backend.Infrastructure.Services.Filters;

public abstract class FilterServiceBase<TEntity, TFilters>(IProductRepository<TEntity> productRepository)
    : IFilterService<TEntity, TFilters> where TEntity : ProductBase
{
    public abstract Filter<TEntity> BuildFilter(IDictionary<string, string> criteria);
    public abstract Task<Result<TFilters>> GetFiltersAsync(CancellationToken stoppingToken = default);

    protected async Task<IReadOnlyList<string>> ListBrandsAsync(CancellationToken stoppingToken) 
        => await productRepository.ListBrandsAsync(stoppingToken);
}