using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;

namespace Backend.Infrastructure.Services.Filters;

public class MotherboardFilterService(IBrandProviderService<Motherboard> brandProviderService)
    : FilterServiceBase<Motherboard>(brandProviderService)
{
    public override Filter<Motherboard> BuildFilter(IDictionary<string, string> criteria) => query => query;

    public override object Filters => new
    {
        Brands,
        Sockets = Enum.GetValues<Socket>().Select(socket => socket.GetEnumMemberValue()),
        FormFactors = Enum.GetValues<FormFactor>().Select(formFactor => formFactor.GetEnumMemberValue()),
        Chipsets = Enum.GetValues<Chipset>().Select(chipset => chipset.GetEnumMemberValue())
    };
}