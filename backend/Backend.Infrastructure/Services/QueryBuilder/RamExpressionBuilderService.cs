using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class RamExpressionBuilderService : IExpressionBuilderService<Ram>
{
    public IQueryable<Ram> Build(IQueryable<Ram> query, IDictionary<string, string> criteria)
    {
        throw new NotImplementedException();
    }
}