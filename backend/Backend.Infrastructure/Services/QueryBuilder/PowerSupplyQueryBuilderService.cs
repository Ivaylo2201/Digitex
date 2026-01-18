using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class PowerSupplyQueryBuilderService : IQueryBuilderService<PowerSupply>
{
    public Query<PowerSupply> BuildQuery(IDictionary<string, string> criteria)
    {
        return query => query;
    }
}