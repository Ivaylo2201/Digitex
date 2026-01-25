using System.Linq.Expressions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class RamExpressionBuilderService : IExpressionBuilderService<Ram>
{
    public Expression<Func<Ram, bool>> Build(IDictionary<string, string> criteria)
    {
        return _ => true;
    }
}