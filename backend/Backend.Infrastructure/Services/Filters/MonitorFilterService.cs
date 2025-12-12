using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;

namespace Backend.Infrastructure.Services.Filters;

using Monitor = Domain.Entities.Monitor;

public class MonitorFilterService(IBrandProviderService<Monitor> brandProviderService)
    : FilterServiceBase<Monitor>(brandProviderService)
{
    public override Filter<Monitor> BuildFilter(IDictionary<string, string> criteria) => filter => filter;

    public override object Filters => new
    {
        Brands,
        RefreshRates = Enum.GetValues<RefreshRate>().Cast<int>().ToList(),
        Matrices = Enum.GetValues<Matrix>().Select(matrix => matrix.GetEnumMemberValue()),
        ResolutionTypes = Enum.GetValues<ResolutionType>().Select(resolutionType => resolutionType.GetEnumMemberValue()),
    };
}