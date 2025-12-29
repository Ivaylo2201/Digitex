using Backend.Application.Interfaces.QueryBuilder;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class GraphicsCardQueryBuilderService : IQueryBuilderService<GraphicsCard>
{
    public Query<GraphicsCard> BuildQuery(IDictionary<string, string> criteria)
    {
        return query => query;
    }
}