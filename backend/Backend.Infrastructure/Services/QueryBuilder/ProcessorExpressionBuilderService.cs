using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class ProcessorExpressionBuilderService : IExpressionBuilderService<Processor>
{
    public IQueryable<Processor> Build(IQueryable<Processor> query, IDictionary<string, string> criteria)
    {
        throw new NotImplementedException();
    }
}