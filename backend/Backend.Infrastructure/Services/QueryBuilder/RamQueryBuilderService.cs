using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class RamQueryBuilderService : QueryBuilderServiceBase<Ram>
{
    public override IQueryable<Ram> Build(IQueryable<Ram> query, IDictionary<string, string> criteria)
    {
        query = base.Build(query, criteria);
        
        if (criteria.TryGetValue("memoryCapacities", out var memoryCaps) && !string.IsNullOrWhiteSpace(memoryCaps))
        {
            var capacityList = memoryCaps
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            query = query.Where(r => capacityList.Contains(r.Memory.CapacityInGb));
        }
        
        if (criteria.TryGetValue("memoryTypes", out var memoryTypes) && !string.IsNullOrWhiteSpace(memoryTypes))
        {
            var typeList = memoryTypes
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Trim().ToLower());

            query = query.Where(r => typeList.Contains(r.Memory.Type.ToString().ToLower()));
        }
        
        if (criteria.TryGetValue("frequencies", out var freqs) && !string.IsNullOrWhiteSpace(freqs))
        {
            var freqList = freqs
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            query = query.Where(r => freqList.Contains(r.Memory.Frequency));
        }

        return query;
    }
}