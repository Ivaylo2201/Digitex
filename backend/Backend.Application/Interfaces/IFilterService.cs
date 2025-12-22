using Backend.Domain.Common;

namespace Backend.Application.Interfaces;

public interface IFilterService<TEntity, out TFilters>
{
    Filter<TEntity> BuildFilter(IDictionary<string, string> criteria);
    TFilters Filters { get; }
}