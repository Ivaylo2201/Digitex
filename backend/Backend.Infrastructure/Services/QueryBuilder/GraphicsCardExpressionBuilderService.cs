using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class GraphicsCardExpressionBuilderService : IExpressionBuilderService<GraphicsCard>
{
    public IQueryable<GraphicsCard> Build(IQueryable<GraphicsCard> query, IDictionary<string, string> criteria)
    {
        if (criteria.TryGetValue("brands", out var brands) && !string.IsNullOrWhiteSpace(brands))
        {
            var brandList = brands.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(b => b.Trim())
                .AsEnumerable();

            query = query.Where(graphicsCard => brandList.Contains(graphicsCard.Brand.BrandName));
        }

        return query;
    }
}