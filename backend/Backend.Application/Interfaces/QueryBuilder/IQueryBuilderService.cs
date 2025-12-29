using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.QueryBuilder;

public interface IQueryBuilderService<TProduct> where TProduct : ProductBase
{
    Query<TProduct> BuildQuery(IDictionary<string, string> criteria);
}