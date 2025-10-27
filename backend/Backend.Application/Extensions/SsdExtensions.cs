using Backend.Application.DTOs.Ssd;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions;

public static class SsdExtensions
{
    public static SsdDto ToSsdDto(this Ssd ssd) => new(ssd)
    {
        CapacityInGb = ssd.CapacityInGb,
        OperationSpeed = ssd.OperationSpeed,
        Interface = ssd.Interface
    };
}