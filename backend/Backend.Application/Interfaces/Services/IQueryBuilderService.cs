using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Services;

public interface IQueryBuilderService<TProduct> where TProduct : ProductBase
{
    Query<TProduct> BuildQuery(IDictionary<string, string> criteria);
}