using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.QueryBuilder;

public class ProcessorQueryBuilderService : QueryBuilderServiceBase<Processor>
{
    public override IQueryable<Processor> Build(IQueryable<Processor> query, IDictionary<string, string> criteria)
    {
        query = base.Build(query, criteria);
        
        if (criteria.TryGetValue("cores", out var cores) && !string.IsNullOrWhiteSpace(cores))
        {
            var coreList = cores.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse);

            query = query.Where(p => coreList.Contains(p.Cores));
        }

        if (criteria.TryGetValue("threads", out var threads) && !string.IsNullOrWhiteSpace(threads))
        {
            var threadList = threads.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse);

            query = query.Where(p => threadList.Contains(p.Threads));
        }

        if (criteria.TryGetValue("sockets", out var sockets) && !string.IsNullOrWhiteSpace(sockets))
        {
            var socketList = sockets
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim().ToLower());

            query = query.Where(p => socketList.Contains(p.Socket.ToString().ToLower()));
        }

        if (criteria.TryGetValue("minTdp", out var minTdp) &&
            int.TryParse(minTdp, out var minTdpValue))
        {
            query = query.Where(p => p.Tdp >= minTdpValue);
        }

        if (criteria.TryGetValue("maxTdp", out var maxTdp) &&
            int.TryParse(maxTdp, out var maxTdpValue))
        {
            query = query.Where(p => p.Tdp <= maxTdpValue);
        }

        return query;
    }
}
