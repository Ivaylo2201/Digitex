using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class MotherboardExpressionBuilderService : IExpressionBuilderService<Motherboard>
{
    public IQueryable<Motherboard> Build(IQueryable<Motherboard> query, IDictionary<string, string> criteria)
    {
        throw new NotImplementedException();
    }
}