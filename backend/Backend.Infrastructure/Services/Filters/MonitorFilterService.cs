using Backend.Application.Dtos.Filters;
using Backend.Application.Interfaces.Filters;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;

namespace Backend.Infrastructure.Services.Filters;

using Monitor = Domain.Entities.Monitor;

public class MonitorFilterService(IBrandProviderService<Monitor> brandProviderService)
    : FilterServiceBase<Monitor, MonitorFilters>(brandProviderService)
{
    public override Filter<Monitor> BuildFilter(IDictionary<string, string> criteria) => filter => filter;

    public override MonitorFilters Filters => new(
        Brands,
        Enum.GetValues<RefreshRate>().Cast<int>().ToList(),
        Enum.GetValues<Matrix>().Select(matrix => matrix.GetEnumMemberValue()).ToList(),
        Enum.GetValues<ResolutionType>().Select(resolutionType => resolutionType.GetEnumMemberValue()).ToList()
    );
}