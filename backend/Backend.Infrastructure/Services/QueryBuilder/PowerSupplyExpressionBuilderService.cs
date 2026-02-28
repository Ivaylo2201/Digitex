using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class PowerSupplyExpressionBuilderService : IExpressionBuilderService<PowerSupply>
{
    public IQueryable<PowerSupply> Build(IQueryable<PowerSupply> query, IDictionary<string, string> criteria)
    {
        throw new NotImplementedException();
    }
}