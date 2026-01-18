using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class RamQueryBuilderService : IQueryBuilderService<Ram>
{
    public Query<Ram> BuildQuery(IDictionary<string, string> criteria)
    {
        return query => query;
    }
}