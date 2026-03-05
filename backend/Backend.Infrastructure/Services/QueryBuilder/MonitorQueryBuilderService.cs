namespace Backend.Infrastructure.Services.QueryBuilder;

using Monitor = Backend.Domain.Entities.Monitor;

public class MonitorQueryBuilderService : QueryBuilderServiceBase<Monitor>
{
    public override IQueryable<Monitor> Build(IQueryable<Monitor> query, IDictionary<string, string> criteria)
    {
        query = base.Build(query, criteria);
        
        if (criteria.TryGetValue("refreshRates", out var refreshRates) && !string.IsNullOrWhiteSpace(refreshRates))
        {
            var refreshRateList = refreshRates
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            query = query.Where(m => refreshRateList.Contains(m.RefreshRate));
        }
        
        if (criteria.TryGetValue("matrices", out var matrices) && !string.IsNullOrWhiteSpace(matrices))
        {
            var matrixList = matrices
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(m => m.Trim().ToLower());

            query = query.Where(m => matrixList.Contains(m.Matrix.ToString().ToLower()));
        }
        
        if (criteria.TryGetValue("resolutionTypes", out var resolutionTypes) && !string.IsNullOrWhiteSpace(resolutionTypes))
        {
            var resolutionList = resolutionTypes
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(r => r.Trim().ToLower());

            query = query.Where(m => resolutionList.Contains(m.Resolution.Type.ToString().ToLower()));
        }
        
        return query;
    }
}