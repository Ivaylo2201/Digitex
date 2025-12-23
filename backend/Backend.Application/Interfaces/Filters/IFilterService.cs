using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Filters;

public interface IFilterService<TEntity, TFilters>
{
    Filter<TEntity> BuildFilter(IDictionary<string, string> criteria);
    Task<Result<TFilters>> GetFiltersAsync(CancellationToken stoppingToken = default);
}