using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Services;

public interface IFilterService<TEntity>
{
    /// <summary>
    /// Constructs an IQueryable filter from query parameters packed in a dictionary.
    /// </summary>
    Filter<TEntity> Build(IDictionary<string, string> criteria);
    
    /// <summary>
    /// Returns an object with filter options for an entity.
    /// </summary>
    object Get();
}