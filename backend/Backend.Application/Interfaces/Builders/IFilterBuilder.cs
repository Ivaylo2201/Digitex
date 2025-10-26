using Backend.Domain.Common;
using Microsoft.Extensions.Primitives;

namespace Backend.Application.Interfaces.Builders;

public interface IFilterBuilder<TEntity>
{
    FilterQuery<TEntity> Build(Dictionary<string, string> criteria);
}