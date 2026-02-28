using Backend.Application.Interfaces.Services;

namespace Backend.Infrastructure.Services.QueryBuilder;

using Monitor = Backend.Domain.Entities.Monitor;

public class MonitorExpressionBuilderService : IExpressionBuilderService<Monitor>
{
    public IQueryable<Monitor> Build(IQueryable<Monitor> query, IDictionary<string, string> criteria)
    {
        return query;
    }
}