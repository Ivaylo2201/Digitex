using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class SsdExpressionBuilderService : IExpressionBuilderService<Ssd>
{
    public IQueryable<Ssd> Build(IQueryable<Ssd> query, IDictionary<string, string> criteria)
    {
        throw new NotImplementedException();
    }
}