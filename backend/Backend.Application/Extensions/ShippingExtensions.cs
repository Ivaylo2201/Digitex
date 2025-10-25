using Backend.Application.DTOs;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions;

public static class ShippingExtensions
{
    public static ShippingDto ToShippingDto(this Shipping shipping)
    {
        return new ShippingDto
        {
            Id = shipping.Id,
            ShippingType = shipping.ShippingType,
            Cost = shipping.Cost,
            Days = shipping.Days
        };
    }
}