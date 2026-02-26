using Backend.Application.DTOs.Products;

namespace Backend.Application.DTOs;

public record OrderDto
{
    public IEnumerable<ItemDto> Items { get; init; } = [];
    public required decimal TotalPrice { get; init; }
}