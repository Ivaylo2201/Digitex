using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class SsdQueryBuilderService : QueryBuilderServiceBase<Ssd>
{
    public override IQueryable<Ssd> Build(IQueryable<Ssd> query, IDictionary<string, string> criteria)
    {
        query = base.Build(query, criteria);
        
        if (criteria.TryGetValue("memoryCapacities", out var memoryCaps) && !string.IsNullOrWhiteSpace(memoryCaps))
        {
            var capacityList = memoryCaps
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            query = query.Where(s => capacityList.Contains(s.CapacityInGb));
        }
        
        if (criteria.TryGetValue("storageInterfaces", out var interfaces) && !string.IsNullOrWhiteSpace(interfaces))
        {
            var interfaceList = interfaces
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.Trim().ToLower());

            query = query.Where(s => interfaceList.Contains(s.StorageInterface.ToString().ToLower()));
        }
        
        if (criteria.TryGetValue("minReadSpeed", out var minRead) && int.TryParse(minRead, out var minReadValue))
        {
            query = query.Where(s => s.OperationSpeed.Read >= minReadValue);
        }

        if (criteria.TryGetValue("maxReadSpeed", out var maxRead) && int.TryParse(maxRead, out var maxReadValue))
        {
            query = query.Where(s => s.OperationSpeed.Read <= maxReadValue);
        }
        
        if (criteria.TryGetValue("minWriteSpeed", out var minWrite) && int.TryParse(minWrite, out var minWriteValue))
        {
            query = query.Where(s => s.OperationSpeed.Write >= minWriteValue);
        }

        if (criteria.TryGetValue("maxWriteSpeed", out var maxWrite) && int.TryParse(maxWrite, out var maxWriteValue))
        {
            query = query.Where(s => s.OperationSpeed.Write <= maxWriteValue);
        }

        return query;
    }
}
