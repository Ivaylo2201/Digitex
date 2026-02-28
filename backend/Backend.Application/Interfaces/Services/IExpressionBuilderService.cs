using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Services;

public interface IExpressionBuilderService<TProduct> where TProduct : ProductBase
{
    IQueryable<TProduct> Build(IQueryable<TProduct> query, IDictionary<string, string> criteria);
}