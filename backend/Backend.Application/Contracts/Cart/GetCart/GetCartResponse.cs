namespace Backend.Application.Contracts.Cart.GetCart;

public record GetCartResponse
{
    public required List<ItemProjection> Items { get; init; }
    public required decimal TotalPrice { get; init; }
}