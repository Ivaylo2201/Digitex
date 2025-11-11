using Backend.Application.Dtos.Product;

namespace Backend.Application.Dtos.Item;

public record ItemDto
{
    public required int Id { get; init; }
    public required ProductItemDto Product { get; init; }
    public required double Price { get; init; }
    public required int Quantity { get; init; }
}