using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;

namespace Backend.Infrastructure.Services.QueryBuilder;

using Monitor = Backend.Domain.Entities.Monitor;

public class MonitorQueryBuilderService : IQueryBuilderService<Monitor>
{
    public Query<Monitor> BuildQuery(IDictionary<string, string> criteria)
    {
        return query => query;
    }
}