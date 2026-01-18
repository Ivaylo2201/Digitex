using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class SsdQueryBuilderService : IQueryBuilderService<Ssd>
{
    public Query<Ssd> BuildQuery(IDictionary<string, string> criteria)
    {
        return query => query;
    }
}