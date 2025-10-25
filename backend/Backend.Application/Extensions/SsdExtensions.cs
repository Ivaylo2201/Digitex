using Backend.Application.DTOs;
using Backend.Domain.Entities;
using Backend.Domain.ValueObjects;

namespace Backend.Application.Extensions;

public static class SsdExtensions
{
    public static SsdDto ToSsdDto(this Ssd ssd)
    {
        return new SsdDto
        {
            Id = ssd.Id,
            BrandName = ssd.Brand.BrandName,
            ModelName = ssd.ModelName,
            ImagePath = ssd.ImagePath,
            Price = new Price
            {
                Initial = ssd.InitialPrice,
                Discounted = ssd.Price
            },
            DiscountPercentage = ssd.DiscountPercentage,
            CapacityInGb = ssd.CapacityInGb,
            OperationSpeed = ssd.OperationSpeed,
            Interface = ssd.Interface
        };
    }
}