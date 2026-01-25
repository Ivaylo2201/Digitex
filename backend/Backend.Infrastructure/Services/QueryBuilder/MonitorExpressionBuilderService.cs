using System.Linq.Expressions;
using Backend.Application.Interfaces.Services;

namespace Backend.Infrastructure.Services.QueryBuilder;

using Monitor = Backend.Domain.Entities.Monitor;

public class MonitorExpressionBuilderService : IExpressionBuilderService<Monitor>
{
    public Expression<Func<Monitor, bool>> Build(IDictionary<string, string> criteria)
    {
        return _ => true;
    }
}