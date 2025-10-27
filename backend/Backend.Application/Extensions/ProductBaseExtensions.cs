using Backend.Application.DTOs.Product;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions;

public static class ProductBaseExtensions
{
    public static ProductShortDto ToProductDto(this ProductBase product) => new(product);
}