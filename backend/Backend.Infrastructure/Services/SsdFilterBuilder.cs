using Backend.Application.Interfaces.Builders;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;

namespace Backend.Infrastructure.Services;

public class SsdFilterBuilder : IFilterBuilder<Ssd>
{
    public FilterQuery<Ssd> Build(Dictionary<string, string> criteria)
        => query => ByInterface(ByOperationSpeed(ByCapacity(query, criteria), criteria), criteria);
    
    private static IQueryable<Ssd> ByCapacity(IQueryable<Ssd> query, Dictionary<string, string> criteria)
    {
        if (criteria.TryGetValue("minCapacity", out var minCapacity) && int.TryParse(minCapacity, out var parsedMinCapacity))
            query = query.Where(ssd => ssd.CapacityInGb >= parsedMinCapacity);
        
        if (criteria.TryGetValue("maxCapacity", out var maxCapacity) && int.TryParse(maxCapacity, out var parsedMaxCapacity))
            query = query.Where(ssd => ssd.CapacityInGb <= parsedMaxCapacity);

        return query;
    }
    
    private static IQueryable<Ssd> ByOperationSpeed(IQueryable<Ssd> query, Dictionary<string, string> criteria)
    {
        if (criteria.TryGetValue("minReadSpeed", out var minReadSpeed) && int.TryParse(minReadSpeed, out var parsedMinReadSpeed))
            query = query.Where(ssd => ssd.OperationSpeed.Read >= parsedMinReadSpeed);
        
        if (criteria.TryGetValue("maxReadSpeed", out var maxReadSpeed) && int.TryParse(maxReadSpeed, out var parsedMaxReadSpeed))
            query = query.Where(ssd => ssd.OperationSpeed.Read <= parsedMaxReadSpeed);
        
        if (criteria.TryGetValue("minWriteSpeed", out var minWriteSpeed) && int.TryParse(minWriteSpeed, out var parsedMinWriteSpeed))
            query = query.Where(ssd => ssd.OperationSpeed.Read >= parsedMinWriteSpeed);
        
        if (criteria.TryGetValue("maxWriteSpeed", out var maxWriteSpeed) && int.TryParse(maxWriteSpeed, out var parsedMaxWriteSpeed))
            query = query.Where(ssd => ssd.OperationSpeed.Write <= parsedMaxWriteSpeed);

        return query;
    }
    
    private static IQueryable<Ssd> ByInterface(IQueryable<Ssd> query, Dictionary<string, string> criteria)
    {
        if (criteria.TryGetValue("storageInterface", out var storageInterface) && Enum.TryParse<StorageInterface>(storageInterface, true, out var parsedStorageInterface))
            query = query.Where(ssd => ssd.Interface == parsedStorageInterface);

        return query;
    }
}