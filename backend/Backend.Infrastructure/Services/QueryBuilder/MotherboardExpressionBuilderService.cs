using System.Linq.Expressions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class MotherboardExpressionBuilderService : IExpressionBuilderService<Motherboard>
{
    public Expression<Func<Motherboard, bool>> Build(IDictionary<string, string> criteria)
    {
        return _ => true;
    }
}