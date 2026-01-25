using System.Linq.Expressions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class GraphicsCardExpressionBuilderService : IExpressionBuilderService<GraphicsCard>
{
    public Expression<Func<GraphicsCard, bool>> Build(IDictionary<string, string> criteria)
    {
        return _ => true;
    }
}