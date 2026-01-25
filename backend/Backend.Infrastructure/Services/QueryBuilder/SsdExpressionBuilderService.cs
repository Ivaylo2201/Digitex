using System.Linq.Expressions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class SsdExpressionBuilderService : IExpressionBuilderService<Ssd>
{
    public Expression<Func<Ssd, bool>> Build(IDictionary<string, string> criteria)
    {
        return _ => true;
    }
}