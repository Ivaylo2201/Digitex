using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Services.Common.Filters;

public class CpuFilterService(IBrandProviderService brandProviderService) : IFilterService<Cpu>
{
    public Filter<Cpu> BuildFilter(IDictionary<string, string> criteria)
    {
        return cpu => cpu;
    }

    public object GetFilters() => new
    {
        Brands = brandProviderService.GetBrands<Cpu>()
    };
}