using System.Linq.Expressions;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class ProcessorExpressionBuilderService : IExpressionBuilderService<Processor>
{
    public Expression<Func<Processor, bool>> Build(IDictionary<string, string> criteria)
    {
        return _ => true;
    }
}