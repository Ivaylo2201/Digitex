using System.Linq.Expressions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class PowerSupplyExpressionBuilderService : IExpressionBuilderService<PowerSupply>
{
    public Expression<Func<PowerSupply, bool>> Build(IDictionary<string, string> criteria)
    {
        return _ => true;
    }
}