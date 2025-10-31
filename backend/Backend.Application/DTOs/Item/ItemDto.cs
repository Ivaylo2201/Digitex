using Backend.Application.DTOs.Product;

namespace Backend.Application.DTOs.Item;

public record ItemDto
{
    public required int Id { get; init; }
    public required ProductItemDto Product { get; init; }
    public required double Price { get; init; }
    public required int Quantity { get; init; }
}