using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class MotherboardQueryBuilderService : IQueryBuilderService<Motherboard>
{
    public Query<Motherboard> BuildQuery(IDictionary<string, string> criteria)
    {
        return query => query;
    }
}