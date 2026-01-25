using System.Linq.Expressions;
using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Services;

public interface IExpressionBuilderService<TProduct> where TProduct : ProductBase
{
    Expression<Func<TProduct, bool>> Build(IDictionary<string, string> criteria);
}