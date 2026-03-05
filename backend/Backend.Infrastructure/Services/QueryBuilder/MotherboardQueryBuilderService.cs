using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class MotherboardQueryBuilderService : QueryBuilderServiceBase<Motherboard>
{
    public override IQueryable<Motherboard> Build(IQueryable<Motherboard> query, IDictionary<string, string> criteria)
    {
        query = base.Build(query, criteria);
        
        if (criteria.TryGetValue("sockets", out var sockets) && !string.IsNullOrWhiteSpace(sockets))
        {
            var socketList = sockets
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim().ToLower());

            query = query.Where(m => socketList.Contains(m.Socket.ToString().ToLower()));
        }
        
        if (criteria.TryGetValue("formFactors", out var formFactors) && !string.IsNullOrWhiteSpace(formFactors))
        {
            var formFactorList = formFactors
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(f => f.Trim().ToLower());

            query = query.Where(m => formFactorList.Contains(m.FormFactor.ToString().ToLower()));
        }
        
        if (criteria.TryGetValue("chipsets", out var chipsets) && !string.IsNullOrWhiteSpace(chipsets))
        {
            var chipsetList = chipsets
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.Trim().ToLower());

            query = query.Where(m => chipsetList.Contains(m.Chipset.ToString().ToLower()));
        }

        return query;
    }
}