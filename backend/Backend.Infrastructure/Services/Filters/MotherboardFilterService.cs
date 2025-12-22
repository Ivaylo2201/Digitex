using Backend.Application.Dtos.Filters;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Extensions;

namespace Backend.Infrastructure.Services.Filters;

public class MotherboardFilterService(IBrandProviderService<Motherboard> brandProviderService)
    : FilterServiceBase<Motherboard, MotherboardFilters>(brandProviderService)
{
    public override Filter<Motherboard> BuildFilter(IDictionary<string, string> criteria) => query => query;

    public override MotherboardFilters Filters => new(
        Brands,
        Enum.GetValues<Socket>().Select(socket => socket.GetEnumMemberValue()).ToList(),
        Enum.GetValues<FormFactor>().Select(formFactor => formFactor.GetEnumMemberValue()).ToList(),
        Enum.GetValues<Chipset>().Select(chipset => chipset.GetEnumMemberValue()).ToList()
    );
}