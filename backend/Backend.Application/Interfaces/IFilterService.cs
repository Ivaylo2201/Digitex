using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Services;

public interface IFilterService<TEntity>
{
    Filter<TEntity> BuildFilter(IDictionary<string, string> criteria);
    object Filters { get; }
}