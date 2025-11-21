using Backend.Application.Dtos.Product;
using Backend.Domain.Entities;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Application.Extensions;

public static class SuggestionDtoExtension
{
    public static SuggestionDto ToSuggestionDto(this ProductBase product)
    {
        return new SuggestionDto
        {
            Id = product.Id,
            Category = product switch
            {
                Processor => "processors",
                Motherboard => "motherboards",
                GraphicsCard => "graphics-cards",
                Ram => "rams",
                Ssd => "ssds",
                PowerSupply => "power-supplies",
                Monitor => "monitors",
                _ => throw new ArgumentException("Invalid product type.", nameof(product))
            },      
            BrandName = product.Brand.BrandName,
            ModelName = product.ModelName,
            ImagePath = product.ImagePath
        };
    }
}