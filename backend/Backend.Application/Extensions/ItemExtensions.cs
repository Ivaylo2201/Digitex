using Backend.Application.DTOs.Item;
using Backend.Application.DTOs.Product;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions;

public static class ItemExtensions
{
    public static ItemDto ToDto(this Item item)
    {
        return new ItemDto
        {
            Id = item.Id,
            Product = new ProductItemDto
            {
                BrandName = item.Product.Brand.BrandName,
                ModelName = item.Product.ModelName,
                Price = item.Product.Price,
                ImagePath = item.Product.ImagePath
            },
            Price = item.Product.Price * item.Quantity,
            Quantity = item.Quantity,
        };
    }
}