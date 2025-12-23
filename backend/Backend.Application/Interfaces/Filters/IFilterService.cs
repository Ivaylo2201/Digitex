using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Filters;

public interface IFilterService<TEntity, out TFilters>
{
    Filter<TEntity> BuildFilter(IDictionary<string, string> criteria);
    TFilters Filters { get; }
}