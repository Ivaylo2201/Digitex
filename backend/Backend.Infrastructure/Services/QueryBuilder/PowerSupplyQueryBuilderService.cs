using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class PowerSupplyQueryBuilderService : QueryBuilderServiceBase<PowerSupply>
{
    public override IQueryable<PowerSupply> Build(IQueryable<PowerSupply> query, IDictionary<string, string> criteria)
    {
        query = base.Build(query, criteria);
        
        if (criteria.TryGetValue("formFactors", out var formFactors) && !string.IsNullOrWhiteSpace(formFactors))
        {
            var formFactorList = formFactors
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(f => f.Trim().ToLower());

            query = query.Where(ps => formFactorList.Contains(ps.FormFactor.ToString().ToLower()));
        }
        
        if (criteria.TryGetValue("modularities", out var modularities) && !string.IsNullOrWhiteSpace(modularities))
        {
            var modularityList = modularities
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(m => m.Trim().ToLower());

            query = query.Where(ps => modularityList.Contains(ps.Modularity.ToString().ToLower()));
        }
        
        if (criteria.TryGetValue("minEfficiencyPercentage", out var minEfficiency) && int.TryParse(minEfficiency, out var minEff))
        {
            query = query.Where(ps => ps.EfficiencyPercentage >= minEff);
        }

        if (criteria.TryGetValue("maxEfficiencyPercentage", out var maxEfficiency) && int.TryParse(maxEfficiency, out var maxEff))
        {
            query = query.Where(ps => ps.EfficiencyPercentage <= maxEff);
        }

        return query;
    }
}