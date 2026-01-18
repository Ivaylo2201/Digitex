using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class ProcessorQueryBuilderService : IQueryBuilderService<Processor>
{
    public Query<Processor> BuildQuery(IDictionary<string, string> criteria)
    {
        return query => query;
    }
}