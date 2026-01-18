using Backend.Application.DTOs;

namespace Backend.Application.UseCases.Carts.GetCart;

public record GetCartResponse
{
    public required IEnumerable<ItemDto> Items { get; init; }
    public required decimal TotalPrice { get; init; }
}