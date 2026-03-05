using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class GraphicsCardQueryBuilderService : QueryBuilderServiceBase<GraphicsCard>
{
    public override IQueryable<GraphicsCard> Build(IQueryable<GraphicsCard> query, IDictionary<string, string> criteria)
    {
        query = base.Build(query, criteria);
        
        if (criteria.TryGetValue("busWidths", out var busWidths) && !string.IsNullOrWhiteSpace(busWidths))
        {
            var busWidthList = busWidths.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse);

            query = query.Where(gc => busWidthList.Contains(gc.BusWidth));
        }

        if (criteria.TryGetValue("memoryCapacities", out var memoryCapacities) && !string.IsNullOrWhiteSpace(memoryCapacities))
        {
            var memoryList = memoryCapacities.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse);

            query = query.Where(gc => memoryList.Contains(gc.Memory.CapacityInGb));
        }

        if (criteria.TryGetValue("cudaCores", out var cudaCores) && !string.IsNullOrWhiteSpace(cudaCores))
        {
            var cudaCoreList = cudaCores.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse);

            query = query.Where(gc => cudaCoreList.Contains(gc.CudaCores));
        }

        if (criteria.TryGetValue("minClockSpeed", out var minClockSpeed) && double.TryParse(minClockSpeed, out var minClockSpeedValue))
        {
            query = query.Where(gc => gc.ClockSpeed.Base >= minClockSpeedValue);
        }

        if (criteria.TryGetValue("maxClockSpeed", out var maxClockSpeed) && double.TryParse(maxClockSpeed, out var maxClockSpeedValue))
        {
            query = query.Where(gc => gc.ClockSpeed.Base <= maxClockSpeedValue);
        }

        return query;
    }
}