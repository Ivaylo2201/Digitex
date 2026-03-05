using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public abstract class QueryBuilderServiceBase<TProduct> : IExpressionBuilderService<TProduct> where TProduct : ProductBase
{
    public virtual IQueryable<TProduct> Build(IQueryable<TProduct> query, IDictionary<string, string> criteria)
    {
        if (criteria.TryGetValue("brands", out var brands) && !string.IsNullOrWhiteSpace(brands))
        {
            var brandList = brands.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(b => b.Trim());

            query = query.Where(p => brandList.Contains(p.Brand.BrandName));
        }
        
        if (criteria.TryGetValue("minPrice", out var minPrice) && decimal.TryParse(minPrice, out var minPriceValue))
        {
            query = query.Where(p => p.InitialPrice >= minPriceValue);
        }

        if (criteria.TryGetValue("maxPrice", out var maxPrice) && decimal.TryParse(maxPrice, out var maxPriceValue))
        {
            query = query.Where(p => p.InitialPrice <= maxPriceValue);
        }

        return query;
    }
}